using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PeterSoft.SonarQubeConnector.Models;

namespace Services.UnitTest
{
    [TestClass]
    public class ConditionTest
    {
        [TestMethod]
        public void SimpleCase()
        {
            string response = @"{'id':27,'metric':'test_failures','op':'GT','warning':'0','error':'5'}";
            Condition condition = DeSerialize(response);
            Assert.AreEqual(27, condition.Id);
            Assert.AreEqual("test_failures", condition.Metric);
            Assert.AreEqual("GT", condition.Op);
            Assert.AreEqual("0", condition.Warning);
            Assert.AreEqual("5", condition.Error);
            Assert.AreEqual(0, condition.Period);
        }

        public void NoWarning()
        {
            string response = @"{'id':27,'metric':'test_failures','op':'GT','error':'5'}";
            Condition condition = DeSerialize(response);
            Assert.AreEqual(null, condition.Warning);
        }

        public void NoError()
        {
            string response = @"{'id':27,'metric':'test_failures','op':'GT','warning':'5'}";
            Condition condition = DeSerialize(response);
            Assert.AreEqual(null, condition.Error);
        }

        public void WithPeriod()
        {
            string response = @"{'id':27,'period':1}";
            Condition condition = DeSerialize(response);
            Assert.AreEqual(1, condition.Period);
        }

        private static Condition DeSerialize(string response)
        {
            return JsonConvert.DeserializeObject<Condition>(response.Replace("'", "\""));
        }
    }
}
