using PeterSoft.SonarQube.Connector.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQube.Connector.Models;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Client;

namespace PeterSoft.SonarQube.Connector.Commands
{
    class DevCockpitRunCommand : ParametersBase, IDevCockpitRunCommand
    {
        public DevCockpitRunCommand(IRestParameters restParameters) : base(restParameters)
        {
        }

        public IList<DeveloperTask> DeveloperTasks { get; set; }
    }
}
