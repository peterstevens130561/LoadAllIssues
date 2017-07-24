using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PeterSoft.SonarQube.Connector.Models;
using Newtonsoft.Json;

namespace Services.UnitTest
{
    [TestClass]
    public class ResourcesTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string response = @"[{ ""id"":9891,""key"":""SimulationServer"",""name"":""SimulationServer"",""scope"":""PRJ"",""qualifier"":""TRK"",""date"":""2016-09-26T03:28:02+0200"",""creationDate"":""2014-02-06T14:06:35+0100"",""lname"":""SimulationServer"",""version"":""main"",""description"":""""}]";
            IList<Resource> resources = JsonConvert.DeserializeObject<IList<Resource>>(response);
            Assert.AreEqual(1, resources.Count);
                var resource = resources[0];
            Assert.AreEqual(9891, resource.Id);
            Assert.AreEqual("SimulationServer", resource.Key);
            Assert.AreEqual("PRJ", resource.Scope);

        }
    }
}
