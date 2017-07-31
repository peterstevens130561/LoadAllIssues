using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands.Factory;
using PeterSoft.SonarQube.Connector.Commands;

namespace PeterSoft.SonarQube.Connector.UnitTest
{
    [TestClass]
    public class AbstractCommandFactoryTest
    {
        private ICredentials credentials;

        [TestMethod]
        public void CreateCommand_Valid_ExpectInstantiated()
        {
            MyAbstractCommandFactory factory = GivenAFactoryWithMyCommand();
            // when we request to create an instance of that command
            var command=factory.CreateCommand<IMyCommand>(credentials);
            //then we expect it to be there
            Assert.IsNotNull(command, "should be created, as a valid interface is specified");
            Assert.IsInstanceOfType(command, typeof(MyCommand));
        }

        [TestMethod]
        public void CreateCommand_InValid_ExpectException()
        {
            MyAbstractCommandFactory factory = GivenAFactoryWithMyCommand();
            try
            {
                var command = factory.CreateCommand<ISillyCommand>(credentials);
            }
            catch (ArgumentException)
            {
                return;
            }
            Assert.Fail("should not be created, as an ivalid interface is specified");

        }

        [TestMethod]
        public void CreateHandler_Valid_ExpectInstantiated()
        {
            MyAbstractCommandFactory factory = GivenAFactoryWithMyCommand();
            var myCommand = new MyCommand(null);
            var myCommandHandler = factory.CreateHandler(myCommand);
            Assert.IsNotNull(myCommandHandler, "should be created, as a valid interface is specified");
            Assert.IsInstanceOfType(myCommandHandler, typeof(MyCommandHandler));
        }

        [TestMethod]
        public void CreateHandler_InValid_ExpectException()
        {
            MyAbstractCommandFactory factory = GivenAFactoryWithMyCommand();
            try
            {
                var myCommand = new MySillyCommand(null);
                var myCommandHandler = factory.CreateHandler(myCommand);
            }
            catch (ArgumentException)
            {
                return;
            }
            Assert.Fail("should not be created, as an ivalid interface is specified");

        }

        private MyAbstractCommandFactory GivenAFactoryWithMyCommand()
        {
            IRestClient restClient = new RestClient();
            credentials = new Credentials("url", "token", "");
            var factory = new MyAbstractCommandFactory(restClient);
            // given a factory with MyCommand
            return factory;
        }

        class MyAbstractCommandFactory : AbstractCommandFactory
        {
            public MyAbstractCommandFactory(IRestClient restClient) : base(restClient)
            {
                Register<IMyCommand, MyCommand, MyCommandHandler>();
            }
        }

        interface IMyCommand : ICommand
        {

        }

        interface ISillyCommand : ICommand
        {

        }

        public class MyCommand : ParametersBase, IMyCommand
        {
            public MyCommand(IRestParameters restParameters) : base(restParameters)
            {
            }
        }

        public class MySillyCommand : ParametersBase, IMyCommand
        {
            public MySillyCommand(IRestParameters restParameters) : base(restParameters)
            {
            }
        }
        class MyCommandHandler : ICommandHandler<MyCommand>
        {
             public MyCommandHandler(IRestClient restClient)
        {
        }
        void ICommandHandler<MyCommand>.Execute(MyCommand command)
            {
                throw new NotImplementedException();
            }
        }
    }

}
