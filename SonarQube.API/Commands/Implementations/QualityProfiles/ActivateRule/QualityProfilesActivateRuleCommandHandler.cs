using PeterSoft.SonarQube.Connector.Client;


namespace PeterSoft.SonarQube.Connector.Commands
{
    class ActivateRuleInQualityProfileCommandHandler : ICommandHandler<IActivateRuleInQualityProfileCommand>
    {
        private readonly IRestClient restClient;
        public ActivateRuleInQualityProfileCommandHandler(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public void Execute(IActivateRuleInQualityProfileCommand command)
        {
            IRestParameters restParameters = command.Parameters();
            restClient.SetPath(@"qualityprofiles/activate_rule").Post(restParameters);
        }
    }
}
