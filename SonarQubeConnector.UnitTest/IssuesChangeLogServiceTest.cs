using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeterSoft.SonarQubeConnector;
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Services;
using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace SonarQubeConnector.UnitTest
{

    [TestClass]
    public class IssuesChangeLogServiceTest : ServiceTestBase<IIssuesChangelogService>
    {
        [TestMethod]
        public override void ParametersTest()
        {
            Mock<IRestClient> clientMock = new Mock<IRestClient>();
            Mock<IRestParameters> restParametersMock = new Mock<IRestParameters>();
            IIssuesChangelogService service = new IssuesChangelogService(clientMock.Object, restParametersMock.Object);

            service.SetIssue("AVnBS7GiYXVaepB6Hdlz");

            restParametersMock.Verify(p => p.SetParameter("issue", "AVnBS7GiYXVaepB6Hdlz"));
        }
        [TestMethod]
        public override void DeserializationTest()
        {
            var client = new Mock<IRestClient>();
            var restParameters = new Mock<IRestParameters>();
            IIssuesChangelogService service = new IssuesChangelogService(client.Object, restParameters.Object);

            string response = @"{ ""changelog"":[{""user"":""stevpet"",""userName"":""Stevens, Peter"",""email"":""peter.stevens@bakerhughes.com"",""creationDate"":""2017-01-28T08:33:09+0100"",""diffs"":[{""key"":""resolution"",""newValue"":""WONTFIX""},{""key"":""assignee""},{""key"":""status"",""newValue"":""RESOLVED"",""oldValue"":""OPEN""}]}]}";
            client.Setup(p => p.SetPath(It.IsAny<string>())).Returns(client.Object);
            client.Setup(p => p.Get(It.IsAny<IRestParameters>())).Returns(response);

            IList<Changelog> changelogs = service.Execute();
            Assert.IsNotNull(changelogs, "should be valid list");
            Assert.AreEqual(1, changelogs.Count);

            Changelog changelog = changelogs[0];
            Assert.AreEqual("stevpet", changelog.User);
            Assert.AreEqual("Stevens, Peter", changelog.UserName);
            Assert.AreEqual("peter.stevens@bakerhughes.com", changelog.Email);
            Assert.AreEqual(new DateTime(2017, 1, 28, 8, 33, 9), changelog.CreationDate);
            Assert.AreEqual(3, changelog.Diffs.Count);
        }

        /// <summary>
        /// Just a test with no response. Doubt whether this will happen in reality, there I'd expect an exception
        /// </summary>
        [TestMethod]
    
        public  void NotFoundTest()
        {
            var client = new Mock<IRestClient>();
            var restParameters = new Mock<IRestParameters>();
            IIssuesChangelogService service = new IssuesChangelogService(client.Object, restParameters.Object);
            client.Setup(p => p.SetPath(It.IsAny<string>())).Returns(client.Object);

            string response = @"{ ""err_code"":404,""err_msg"":""Issue with key 'AVnBS7GiYXVaepB6Hdl' does not exist""}";
            client.Setup(p => p.Get(It.IsAny<IRestParameters>())).Returns(response);

            IList<Changelog> changelogs = service.Execute();
            Assert.IsNull(changelogs,"expect no serialization");
        }

        [TestMethod]
        public override void RegistrationTest()
        {
            BaseRegistrationTest();
        }
    }
}
