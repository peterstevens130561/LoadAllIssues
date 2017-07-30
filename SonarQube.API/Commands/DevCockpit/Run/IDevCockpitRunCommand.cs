using PeterSoft.SonarQube.Connector.Infrastructure.Commands;
using PeterSoft.SonarQube.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Commands
{
    public interface IDevCockpitRunCommand : ICommand
    {
        /// <summary>
        /// Provides list of tasks, returned by post commands
        /// </summary>
         IList<DeveloperTask> DeveloperTasks { get; set; }
    }
}
