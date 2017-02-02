using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Services;

namespace SonarQubeConnector.UnitTest
{
    /// <summary>
    /// Base testset for Services.
    /// 
    /// Includes registrationset, so the first thing to do when creating a service is to define empty
    /// interface and implementation, and add these to the connector
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public abstract class ServiceTestBase<T> : IServiceTest where T : IService 
    {
        protected Mock<IRestClient> clientMock;
        protected Mock<IRestParameters> restParametersMock = new Mock<IRestParameters>();
        [TestInitialize] 
        public void TestInitializeBase()
        {
            clientMock = new Mock<IRestClient>();
            restParametersMock = new Mock<IRestParameters>();
        }

        public abstract void DeserializationTest();
        public abstract void ParametersTest();

        /// <summary>
        /// Helper method to create service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T createService()
        {
            var connector = new PeterSoft.SonarQubeConnector.SonarQubeConnector();
            var session = connector.CreateSession();
            return session.CreateService<T>(clientMock.Object,restParametersMock.Object);
        }

        public abstract void RegistrationTest();

        protected void BaseRegistrationTest()
        {
            var service = createService();
            Assert.IsInstanceOfType(service, typeof(T));
        }
    }
}
