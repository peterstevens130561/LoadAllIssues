﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Connector.UnitTest;
using Moq;
using PeterSoft.SonarQube.Connector.Models;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Services;
using System;

namespace PeterSoft.SonarQube.Connector.UnitTest
{
    [TestClass]
    public class PermissionSearchTemplateServiceTest : ServiceTestBase<IPermissionsSearchTemplateService>
    {
        string bigResponse = @"
{
  ""permissionTemplates"": [
    {
      ""id"": ""AU-TpxcA-iU5OvuD2FL0"",
      ""name"": ""Default template for Developers"",
      ""projectKeyPattern"": "".*sonar.developer.*"",
      ""createdAt"": ""2004-11-15T07:26:40+0100"",
      ""updatedAt"": ""2004-11-19T22:33:20+0100"",
      ""permissions"": [
        {
          ""key"": ""user"",
          ""usersCount"": 0,
          ""groupsCount"": 1
        }
      ]
    },
    {
      ""id"": ""AU-Tpxb--iU5OvuD2FLy"",
      ""name"": ""Default template for Projects"",
      ""description"": ""Template for new projects"",
      ""createdAt"": ""2001-09-09T03:46:40+0200"",
      ""updatedAt"": ""2001-09-09T03:46:40+0200"",
      ""permissions"": [
        {
          ""key"": ""admin"",
          ""usersCount"": 0,
          ""groupsCount"": 1
        },
        {
          ""key"": ""codeviewer"",
          ""usersCount"": 1,
          ""groupsCount"": 0
        },
        {
          ""key"": ""issueadmin"",
          ""usersCount"": 3,
          ""groupsCount"": 0
        }
      ]
    },
    {
      ""id"": ""AU-TpxcA-iU5OvuD2FLz"",
      ""name"": ""Default template for Views"",
      ""description"": ""Template for new views"",
      ""projectKeyPattern"": "".*sonar.views.*"",
      ""createdAt"": ""2001-09-09T03:46:40+0200"",
      ""updatedAt"": ""2004-11-09T12:33:20+0100"",
      ""permissions"": [
        {
          ""key"": ""issueadmin"",
          ""usersCount"": 0,
          ""groupsCount"": 3
        },
        {
          ""key"": ""user"",
          ""usersCount"": 2,
          ""groupsCount"": 0
        }
      ]
    }
  ],
  ""defaultTemplates"": [
    {
      ""templateId"": ""AU-Tpxb--iU5OvuD2FLy"",
      ""qualifier"": ""TRK""
    },
    {
      ""templateId"": ""AU-TpxcA-iU5OvuD2FLz"",
      ""qualifier"": ""VW""
    },
    {
      ""templateId"": ""AU-TpxcA-iU5OvuD2FL0"",
      ""qualifier"": ""DEV""
    }
  ]
}

";

string emptyResponse = @"
{
  ""permissionTemplates"": [ ],
  ""defaultTemplates"": []
}

";
        [TestMethod]
        public override void DeserializationTest()
        {
            var service = createService();

            string response = bigResponse;

            clientMock.Setup(p => p.Get(It.IsAny<IRestParameters>())).Returns(response);
            clientMock.Setup(p => p.SetPath(It.IsAny<string>())).Returns(clientMock.Object);

            var permissionTemplates = service.Execute();
            Assert.IsNotNull(permissionTemplates, "should be valid list");
            Assert.AreEqual(2, permissionTemplates.permissionTemplates.Count);
        }

        [TestMethod]
        public void ServiceInstantiationTest()
        {
            RestClient restGetter = null;
            IRestParameters parameters = null;
            var service = new PermissionsSearchTemplateService(restGetter, parameters);
            Activator.CreateInstance(typeof(PermissionsSearchTemplateService), restGetter, parameters);
        }
        [TestMethod]
        public override void ParametersTest()
        {
            var service = createService();

            clientMock.Setup(p => p.Get(It.IsAny<IRestParameters>())).Returns(emptyResponse);
            clientMock.Setup(p => p.SetPath(It.IsAny<string>())).Returns(clientMock.Object);

            PermissionTemplates permissionTemplates = service.Execute();
            Assert.IsNotNull(permissionTemplates, "should be valid list");
 
        }

        [TestMethod]
        public override void RegistrationTest()
        {
            BaseRegistrationTest();
        }

    }
}
