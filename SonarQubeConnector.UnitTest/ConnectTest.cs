using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQube.Connector;
using PeterSoft.SonarQube.Connector.Services;
using PeterSoft.SonarQube.Connector.API.Logic;
using Moq;

namespace Connector.UnitTest
{
    /// <summary>
    /// Summary description for ConnectTest
    /// </summary>
    [TestClass]
    public class ConnectTest
    {
        public ConnectTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        /// <summary>
        /// Test a connect with a token
        /// </summary>
        [TestMethod]
        public void ConnectGetWithToken()
        {
            var restClientMock = new Mock<RestClient>();
            var connector = new SonarQubeConnector(restClientMock.Object);
            var session = connector.CreateSession();
            string server = "http://bogus";
            string token = "3795b31a6ad2e29a03ebe9a6897675e38200fdb9";
            session.ConnectWithToken(server,token);
            IProjectsIndexService projectsIndexService = session.CreateService<IProjectsIndexService>();
            restClientMock.Verify(client => client.SetCredentials(server, token, ""));
        }
    }
}
