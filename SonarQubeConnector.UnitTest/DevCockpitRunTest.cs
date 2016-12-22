using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQubeConnector.Commands;
namespace PeterSoft.SonarQubeConnector.UnitTest
{
    [TestClass]
    public class DevCockpitRunTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sonarQubeConnector = new SonarQubeConnector();
            var session = sonarQubeConnector.CreateSession();
            var devCockpitRunCommand = session.CreateCommand<IDevCockpitRunCommand>();
            session.SubmitCommand(devCockpitRunCommand);
            var tasks = devCockpitRunCommand.DeveloperTasks;
        }
    }
}
