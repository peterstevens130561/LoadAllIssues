using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeterSoft.SonarQube.Connector.API.Logic;
using PeterSoft.SonarQube.Connector.Services;
using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.UnitTest
{
    [TestClass]
    public class SourcesScmServiceTest : ServiceTestBase<ISourcesScmService>
    {
        [TestMethod]
    public override void DeserializationTest()
    {
        var service = createService();

            string response = @"{
  ""scm"": [
    [1, ""julien"", ""2013-03-13T12:34:56+0100"", ""a1e2b3e5d6f5""],
    [2, ""julien"", ""2013-03-14T13:17:22+0100"", ""b1e2b3e5d6f5""],
    [3, ""simon"", ""2014-01-01T15:35:36+0100"", ""c1e2b3e5d6f5""]
  ]
}";
        clientMock.Setup(p => p.Get(It.IsAny<IRestParameters>())).Returns(response);
        clientMock.Setup(p => p.SetPath(It.IsAny<string>())).Returns(clientMock.Object);

        IList<Commit> commits = service.Execute();
        Assert.IsNotNull(commits, "should be valid list");
        //check the values here
        Assert.AreEqual(3, commits.Count);
        //Assert.AreEqual(@*value*", transitions[0]);
    }

    [TestMethod]
    public override void ParametersTest()
    {
        var service = createService();
        // service.Set*parameter*(value);
        // parameters to set here


        //restParametersMock.Verify(p => p.SetParameter(*key*, *value*));
    }

    [TestMethod]
    public override void RegistrationTest()
    {
        BaseRegistrationTest();
    }
}
}
