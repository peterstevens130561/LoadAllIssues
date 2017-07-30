using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQube.Connector.Client;
using Moq;
using PeterSoft.SonarQube.Connector.Services;
using System.Collections.Generic;
using PeterSoft.SonarQube.Connector.Models;

namespace PeterSoft.SonarQube.Connector.UnitTest
{
    [TestClass]
    public class IssuesAuthorsServiceTest : ServiceTestBase<IIssuesAuthorsService>
    {
        [TestMethod]
        public override void ParametersTest()
        {
            var service = createService();
            service.SetSize(10);
            service.SetPattern("stev");

            restParametersMock.Verify(p => p.SetParameter("ps", "10"));
            restParametersMock.Verify(p => p.SetParameter("q", "stev"));
        }

        [TestMethod]
        public override void DeserializationTest()
        {
            var service = createService();

            string response = @"{""authors"":[""alex.siepman@bakerhughes.com"",""alexander.igubnov@bakerhughes.com""]}";
            clientMock.Setup(p => p.Get(It.IsAny<IRestParameters>())).Returns(response);
            clientMock.Setup(p => p.SetPath(It.IsAny<string>())).Returns(clientMock.Object);

            IList<String> authors = service.Execute();
            Assert.IsNotNull(authors, "should be valid list");
            Assert.AreEqual(2, authors.Count);
            Assert.AreEqual(@"alex.siepman@bakerhughes.com", authors[0]);
            Assert.AreEqual(@"alexander.igubnov@bakerhughes.com", authors[1]);
        }

        [TestMethod]
        public override void RegistrationTest()
        {
            BaseRegistrationTest();
        }

    }
}
