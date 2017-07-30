using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Services;
using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.UnitTest
{
    [TestClass]
    public class PluginsAvailableServiceTest : ServiceTestBase<IPluginsAvailableService>
    {
        public override void DeserializationTest()
        {

        }

        [TestMethod]
        public override void ParametersTest()
        {
            var service = createService();
        }

        [TestMethod]
        public override void RegistrationTest()
        {
            base.BaseRegistrationTest();
        }
    }
}
