using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQube.Connector.Services;
using Newtonsoft.Json;
using PeterSoft.SonarQube.Connector.Models;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using PeterSoft.SonarQube.Connector.Client;
using Moq;

namespace PeterSoft.SonarQube.Connector.UnitTest
{
    [TestClass]
    public class DuplicationsShowServiceTest : ServiceTestBase<IDuplicationsShowService>
    {

        // example of query 
        //http://dftweb02:9000/api/duplications/show?key=Transformer-Bhi.Esie.TooLink:Transformer-Bhi.Esie.TooLink:2A0B26D5-85DB-4FF6-8CC0-9BFE36D4B043:Decoder/DecodingDataProvider.cs
        //
        string response = @"{
                ""duplications"": [
                  {
      ""blocks"": [
                      {
          ""from"": 94, ""size"": 101, ""_ref"": ""1""
        },
        {
          ""from"": 83, ""size"": 101, ""_ref"": ""2""
        }
      ]
    },
    {
      ""blocks"": [
        {
          ""from"": 38, ""size"": 40, ""_ref"": ""1""
        },
        {
          ""from"": 29, ""size"": 39, ""_ref"": ""2""
        }
      ]
    },
    {
      ""blocks"": [
        {
          ""from"": 148, ""size"": 24, ""_ref"": ""1""
        },
        {
          ""from"": 137, ""size"": 24, ""_ref"": ""2""
        },
        {
          ""from"": 137, ""size"": 24, ""_ref"": ""3""
        }
      ]
    }
  ],
  ""files"": {
    ""1"": {
      ""key"": ""org.codehaus.sonar:sonar-plugin-api:src/main/java/org/sonar/api/utils/command/CommandExecutor.java"",
      ""name"": ""CommandExecutor"",
      ""projectName"": ""SonarQube""
    },
    ""2"": {
      ""key"": ""com.sonarsource.orchestrator:sonar-orchestrator:src/main/java/com/sonar/orchestrator/util/CommandExecutor.java"",
      ""name"": ""CommandExecutor"",
      ""projectName"": ""SonarSource :: Orchestrator""
    },
    ""3"": {
      ""key"": ""org.codehaus.sonar.runner:sonar-runner-api:src/main/java/org/sonar/runner/api/CommandExecutor.java"",
      ""name"": ""CommandExecutor"",
      ""projectName"": ""SonarSource Runner""
    }
  }
}";
        public override void DeserializationTest()
        {


        }
        [TestMethod]
        public override void ParametersTest()
        {
            var service = createService();
            var chain = service.SetFileKey("myfile");
            Assert.AreSame(service, chain);
            chain = service.SetUUID("myuuid");
            Assert.AreSame(service, chain);
            restParametersMock.Verify(p => p.SetParameter("fileKey", "myfile"));
            restParametersMock.Verify(p => p.SetParameter("uuid", "myuuid"));
        }

        public override void RegistrationTest()
        {
            BaseRegistrationTest();
        }

        [TestMethod]
        public void TestDeserialization()
        {
            var service = createService();
            clientMock.Setup(p => p.Get(It.IsAny<IRestParameters>())).Returns(response);
            var duplications = service.Execute();
            Assert.AreEqual(3, duplications.Duplications.Count);
            Assert.AreEqual(3, duplications.Files.Count);
        }
    }
}
