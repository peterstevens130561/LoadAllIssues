﻿using PeterSoft.SonarQube.Connector.API.Logic;
using PeterSoft.SonarQube.Connector.Commands;
using PeterSoft.SonarQube.Connector.Infrastructure.Commands;
using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;


namespace PeterSoft.SonarQube.Connector.CommandHandlers
{
    internal class DevCockpitRunCommandHandler : ICommandHandler<IDevCockpitRunCommand>
    {
        private readonly IRestClient restClient;
        public DevCockpitRunCommandHandler(IRestClient restClient)
        {
            this.restClient = restClient;
        }
    public void Execute(IDevCockpitRunCommand command)
        {
            restClient.SetPath(@"devcockpit/run").Post(null);

            command.DeveloperTasks = restClient.GetPostResult<IList<DeveloperTask>>();
        }
    }
}
