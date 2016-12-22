using PeterSoft.SonarQubeConnector.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQubeConnector.Models;

namespace PeterSoft.SonarQubeConnector.Commands
{
    class DevCockpitRunCommand : IDevCockpitRunCommand
    {
        public IList<DeveloperTask> DeveloperTasks { get; set; }
    }
}
