using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQube.Connector.API.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitTest
{
    [TestClass]
    public class EffortConversionTest
    {
        [TestMethod]
        public void TestMin()
        {
            string effort = "1min";
            int actual = EffortConversion.ConvertToMin(effort);
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void TestHour()
        {
            string effort = "1h";
            int actual = EffortConversion.ConvertToMin(effort);
            Assert.AreEqual(60,actual);
        }

        [TestMethod]
        public void TestDay()
        {
            string effort = "123d";
            int actual = EffortConversion.ConvertToMin(effort);
            Assert.AreEqual(123*480,actual);
        }

        [TestMethod]
        public void TestDayHour()
        {
            string effort = "1d 4h";
            int actual = EffortConversion.ConvertToMin(effort);
            Assert.AreEqual(720,actual);
        }

        [TestMethod]
        public void TestHourMin()
        {
            string effort = "1h 8min";
            int actual = EffortConversion.ConvertToMin(effort);
            Assert.AreEqual(68,actual);
        }

        [TestMethod]
        public void TestDayMin()
        {
            string effort = "1d 8min";
            int actual = EffortConversion.ConvertToMin(effort);
            Assert.AreEqual(488, actual);
        }

        [TestMethod]
        public void TestDayHourMin()
        {
            string effort = "1d7h8min";
            int actual = EffortConversion.ConvertToMin(effort);
            Assert.AreEqual(480+420+8, actual);
        }
    }
}
