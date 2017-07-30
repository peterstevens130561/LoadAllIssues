
using PeterSoft.SonarQube.Connector.Client;



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
