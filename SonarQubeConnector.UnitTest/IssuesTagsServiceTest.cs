using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQube.Connector.Services;
using PeterSoft.SonarQube.Connector.Client;
using System.Collections.Generic;
using Moq;

namespace PeterSoft.SonarQube.Connector.UnitTest
{
    [TestClass]
    public class IssuesTagsServiceTest : ServiceTestBase<IIssuesTagsService>
    {
        [TestMethod]
        public override void DeserializationTest()
        {
            var service = createService();

            string response = @"{ ""tags"":[""api-design"",""backbone""]}";

            clientMock.Setup(p => p.Get(It.IsAny<IRestParameters>())).Returns(response);
            clientMock.Setup(p => p.SetPath(It.IsAny<string>())).Returns(clientMock.Object);

            IList<String> tags = service.Execute();
            Assert.IsNotNull(tags, "should be valid list");
            Assert.AreEqual(2, tags.Count);
            Assert.AreEqual(@"api-design", tags[0]);
            Assert.AreEqual(@"backbone", tags[1]);
        }

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
        public override void RegistrationTest()
        {
            BaseRegistrationTest();
        }

    }
}
