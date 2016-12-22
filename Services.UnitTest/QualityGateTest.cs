using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PeterSoft.SonarQubeConnector.Models;

namespace Services.UnitTest
{
    [TestClass]
    public class QualityGateTest
    {
        [TestMethod]
        public void DeserializeNormal()
        {
            string response = @"{ 'id':3, 'name':'CleanSweep', 'conditions':[{'id':14,'metric':'blocker_violations','op':'GT','warning':'0','error':'0'},{'id':15,'metric':'new_critical_violations','op':'GT','warning':'0','error':'0','period':1},{'id':19,'metric':'new_coverage','op':'LT','warning':'60','error':'40','period':1},{'id':26,'metric':'new_sqale_debt_ratio','op':'GT','warning':'1','error':'3','period':1},{'id':27,'metric':'test_failures','op':'GT','warning':'0','error':'0'},{'id':28,'metric':'new_bugs','op':'GT','warning':'0','error':'2','period':1},{'id':29,'metric':'new_vulnerabilities','op':'LT','warning':'0','error':'0','period':1}]}";
            var qualityGate = DeSerialize(response);
            Assert.AreEqual(3, qualityGate.Id);
            Assert.AreEqual(7, qualityGate.Conditions.Count);
            Assert.AreEqual("CleanSweep", qualityGate.Name);

        }

        private static QualityGate DeSerialize(string response)
        {
            return JsonConvert.DeserializeObject<QualityGate>(response.Replace("'", "\""));
        }
    }
}
