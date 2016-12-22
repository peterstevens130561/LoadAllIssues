using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Commands;
using PeterSoft.SonarQubeConnector.Infrastructure.Commands;
using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;


namespace PeterSoft.SonarQubeConnector.CommandHandlers
{
    internal class DevCockpitRunCommandHandler : ICommandHandler<IDevCockpitRunCommand>
    {
        private readonly RestClient restClient;
        public DevCockpitRunCommandHandler(RestClient restClient)
        {
            this.restClient = restClient;
        }
    public void Execute(IDevCockpitRunCommand command)
        {
            restClient.SetPath("devcockpit/run").Post(null);

            command.DeveloperTasks = restClient.GetPostResult<IList<DeveloperTask>>();
        }
    }
}
