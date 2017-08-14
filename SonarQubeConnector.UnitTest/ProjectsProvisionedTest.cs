using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQube.Connector.Client;
using Moq;
using Newtonsoft.Json;
using PeterSoft.SonarQube.Connector.Services;

namespace Connector.UnitTest
{
    [TestClass]
    public class ProjectsProvisionedTest : IPagedServiceTest
    {
        private string pageResponse = @"
{
  ""projects"": [
    {
      ""uuid"": ""ce4c03d6-430f-40a9-b777-ad877c00aa4d"",
      ""key"": ""org.apache.hbas:hbase"",
      ""name"": ""HBase"",
      ""creationDate"": ""2015-03-04T23:03:44+0100""
    },
    {
      ""uuid"": ""c526ef20-131b-4486-9357-063fa64b5079"",
      ""key"": ""com.microsoft.roslyn:roslyn"",
      ""name"": ""Roslyn"",
      ""creationDate"": ""2013-03-04T23:03:44+0100""
    }
  ],
  ""total"": 2,
  ""p"": 1,
  ""ps"": 100
}";
        [TestMethod]
        public void PageTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ParametersTest()
        {
            throw new NotImplementedException();
        }


        [TestMethod]
        public void DeserializationTest()
        {
            var provisionedProjects = JsonConvert.DeserializeObject<ProjectsProvisionedPage>(pageResponse);
            Assert.AreEqual(2, provisionedProjects.Projects.Count);
            var project = provisionedProjects.Projects[0];
            Assert.AreEqual("ce4c03d6-430f-40a9-b777-ad877c00aa4d", project.Uuid);
            Assert.AreEqual("org.apache.hbas:hbase", project.Key);
            Assert.AreEqual("HBase", project.Name);
            Assert.AreEqual(DateTime.Parse("2015-03-04T23:03:44+0100"), project.CreationDate);

            project = provisionedProjects.Projects[1];
            Assert.AreEqual("c526ef20-131b-4486-9357-063fa64b5079", project.Uuid);
            Assert.AreEqual("com.microsoft.roslyn:roslyn", project.Key);
            Assert.AreEqual("Roslyn", project.Name);
            Assert.AreEqual(DateTime.Parse("2013-03-04T23:03:44+0100"), project.CreationDate);

        }
    }
}
