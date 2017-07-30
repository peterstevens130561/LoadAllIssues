using PeterSoft.SonarQube.Connector.API.Logic;
using PeterSoft.SonarQube.Connector.Commands;
using PeterSoft.SonarQube.Connector.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Commands
{
    internal class PermissionsDeleteTemplateCommandHandler : ICommandHandler<PermissionsDeleteTemplateCommand>
    {
        private readonly RestClient restClient; 

        public PermissionsDeleteTemplateCommandHandler(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public void Execute(PermissionsDeleteTemplateCommand command)
        {
            IRestParameters restParameters = command.Parameters();
            restClient.SetPath(@"permissions/delete_template").Post(restParameters);

        }
    }
}
