using PeterSoft.SonarQube.Connector.API.Logic;
using PeterSoft.SonarQube.Connector.Commands;
using PeterSoft.SonarQube.Connector.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.CommandHandlers
{
    internal class PermissionsCreateTemplateCommandHandler : ICommandHandler<PermissionsCreateTemplateCommand>
    {
        private readonly RestClient restClient; 

        public PermissionsCreateTemplateCommandHandler(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public void Execute(PermissionsCreateTemplateCommand command)
        {
            IRestParameters restParameters = command.Parameters();
            restClient.SetPath(@"permissions/create_template").Post(restParameters);
        }
    }
}
