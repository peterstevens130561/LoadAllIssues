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
    internal class PermissionsBulkApplyTemplateCommandHandler : ICommandHandler<PermissionsBulkApplyTemplateCommand>
    {
        private readonly RestClient restClient; 

        public PermissionsBulkApplyTemplateCommandHandler(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public void Execute(PermissionsBulkApplyTemplateCommand command)
        {
            IRestParameters restParameters = command.Parameters();
            restClient.SetPath(@"permissions/bulk_apply_template").Post(restParameters);

        }
    }
}
