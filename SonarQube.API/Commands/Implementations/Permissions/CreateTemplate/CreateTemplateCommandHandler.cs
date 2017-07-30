
using PeterSoft.SonarQube.Connector.Client;

namespace PeterSoft.SonarQube.Connector.Commands
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
