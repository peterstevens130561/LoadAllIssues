﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQube.Connector.Services;

namespace Connector.UnitTest
{
    [TestClass]
    public class DuplicationsShowServiceTest : ServiceTestBase<IDuplicationsShowService>
    {
        public override void DeserializationTest()
        {
            string response = @"
                {
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

        }
        public override void ParametersTest()
        {
            var service = createService();
            var chain = service.SetFileKey("myfile");
            Assert.AreSame(service, chain);
            chain=service.SetUUID("myuuid");
        }

        public override void RegistrationTest()
        {
            BaseRegistrationTest();
        }
    }
}
