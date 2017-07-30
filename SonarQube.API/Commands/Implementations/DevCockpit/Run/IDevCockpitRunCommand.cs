
using PeterSoft.SonarQube.Connector.Models;

using System.Collections.Generic;


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
