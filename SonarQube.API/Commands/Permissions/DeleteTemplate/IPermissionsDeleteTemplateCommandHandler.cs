using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Infrastructure.Commands;


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
