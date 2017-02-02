using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQubeConnector.API.Logic;
using System.Collections.Generic;
using PeterSoft.SonarQubeConnector.Models;

namespace SonarQubeConnector.UnitTest
{
    [TestClass]
    public class QualityProfilesSearchTest
    {
        [TestMethod]
        public void DeserializeTest()
        {
            var client = new RestClient();
            client.Result = @"{
            ""profiles"": [
    {
                ""key"": ""sonar-way-cs-12345"",
      ""name"": ""Sonar way"",
      ""language"": ""cs"",
      ""languageName"": ""C#"",
      ""isInherited"": false,
      ""activeRuleCount"": 37,
      ""isDefault"": true
    },
    {
                ""key"": ""my-bu-profile-java-34567"",
      ""name"": ""My BU Profile"",
      ""language"": ""java"",
      ""languageName"": ""Java"",
      ""isInherited"": true,
      ""parentKey"": ""my-company-profile-java-23456"",
      ""parentName"": ""My Company Profile"",
      ""activeRuleCount"": 72,
      ""isDefault"": false,
      ""projectCount"": 13
    },
    {
      ""key"": ""my-company-profile-java-23456"",
      ""name"": ""My Company Profile"",
      ""language"": ""java"",
      ""languageName"": ""Java"",
      ""isInherited"": false,
      ""isDefault"": true,
      ""activeRuleCount"": 42
    },
    {
      ""key"": ""sonar-way-python-01234"",
      ""name"": ""Sonar way"",
      ""language"": ""py"",
      ""languageName"": ""Python"",
      ""isInherited"": false,
      ""activeRuleCount"": 125,
      ""isDefault"": true
    }
  ]
}";
            Response response = client.GetPostResult<Response>();
            Assert.AreEqual(4, response.profiles.Count);
        }
    }

    class Response
    {
            public IList<Profile> profiles { get; set; }
    }
}
