using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQube.Connector.Services;
using Moq;
using System.Collections.Generic;
using PeterSoft.SonarQube.Connector.API.Logic;

namespace PeterSoft.SonarQube.Connector.UnitTest
{
    [TestClass]
    public class IssuesTransitionsServiceTest : ServiceTestBase<IIssuesTransitionsService>
    {
        [TestMethod]
        public override void DeserializationTest()
        {
            var service = createService();

            string response = @"{""transitions"":[""reopen""]}";
            clientMock.Setup(p => p.Get(It.IsAny<IRestParameters>())).Returns(response);
            clientMock.Setup(p => p.SetPath(It.IsAny<string>())).Returns(clientMock.Object);

            IList<String> transitions = service.Execute();
            Assert.IsNotNull(transitions, "should be valid list");
            Assert.AreEqual(1, transitions.Count);
            Assert.AreEqual(@"reopen", transitions[0]);
        }

        [TestMethod]
        public override void ParametersTest()
        {
            var service = createService();
            service.SetIssue("AVnBS7GiYXVaepB6Hdlz");

            restParametersMock.Verify(p => p.SetParameter("issue", "AVnBS7GiYXVaepB6Hdlz"));
        }

        [TestMethod]
        public override void RegistrationTest()
        {
            BaseRegistrationTest();
        }
    }
}
