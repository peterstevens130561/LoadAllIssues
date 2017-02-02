using PeterSoft.SonarQubeConnector.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQubeConnector.Models;
using PeterSoft.SonarQubeConnector.Client;
using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Commands
{
    class DevCockpitRunCommand : ParametersBase, IDevCockpitRunCommand
    {
        public DevCockpitRunCommand(IRestParameters restParameters) : base(restParameters)
        {
        }

        public IList<DeveloperTask> DeveloperTasks { get; set; }
    }
}
