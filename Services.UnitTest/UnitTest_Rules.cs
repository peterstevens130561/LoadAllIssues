
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PeterSoft.SonarQube.Connector.Models;

namespace Services.UnitTest
{
    [TestClass]
    public class UnitTest_Rules
    {
        readonly string response = @"{""rule"":{""key"":""resharper-cs:NonReadonlyMemberInGetHashCode"",
                ""repo"":""resharper-cs"",
                ""name"":""NonReadonlyMemberInGetHashCode"",
                ""createdAt"":""2016-02-02T09:43:49+0100"",
                ""htmlDesc"":""Non-readonly type member referenced in 'GetHashCode()' < br /> (Category: Potential Code Quality Issues)"",
                ""mdDesc"":""Non-readonly type member referenced in 'GetHashCode()' < br /> (Category: Potential Code Quality Issues)"",
                ""severity"":""MAJOR"",""status"":""READY"",
                ""isTemplate"":false,
                ""tags"":[],
                ""sysTags"":[],
                ""lang"":""cs"",
                ""langName"":""C#"",
                ""params"":[],
                ""debtOverloaded"":false,
                ""remFnOverloaded"":false,
                ""type"":""CODE_SMELL""},
                ""actives"":[]}";
        [TestMethod]
        public void TestMethod1()
        {
            RulesShow rule = JsonConvert.DeserializeObject<RulesShow>(response);
            Assert.AreEqual("resharper-cs:NonReadonlyMemberInGetHashCode", rule.Rule.Key);
        }

        [TestMethod]
        public void TestMethodRepo()
        {
            RulesShow rule = JsonConvert.DeserializeObject<RulesShow>(response);
            Assert.AreEqual("resharper-cs", rule.Rule.Repo);
        }

        [TestMethod]
        public void TestMethodType()
        {
            RulesShow rule = JsonConvert.DeserializeObject<RulesShow>(response);
            Assert.AreEqual("CODE_SMELL", rule.Rule.Type);
        }
    }
}
