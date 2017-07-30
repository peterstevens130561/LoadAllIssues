using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands;
using PeterSoft.SonarQube.Connector.Infrastructure.Commands;

namespace PeterSoft.SonarQube.Connector.Commands
{
    internal class PermissionsApplyTemplateCommandHandler : ICommandHandler<PermissionsApplyTemplateCommand>
    {
        private readonly RestClient restClient; 

        public PermissionsApplyTemplateCommandHandler(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public void Execute(PermissionsApplyTemplateCommand command)
        {
            IRestParameters restParameters = command.Parameters();
            restClient.SetPath(@"permissions/apply_template").Post(restParameters);

        }
    }
}
