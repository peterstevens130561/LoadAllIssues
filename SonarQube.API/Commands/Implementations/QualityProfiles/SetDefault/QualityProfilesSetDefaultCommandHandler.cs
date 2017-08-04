using PeterSoft.SonarQube.Connector.Client;


namespace PeterSoft.SonarQube.Connector.Commands
{
    class QualityProfilesSetDefaultCommandHandler : ICommandHandler<IQualityProfilesSetDefaultCommand>
    {
        private readonly IRestClient restClient;
        public QualityProfilesSetDefaultCommandHandler(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public void Execute(IQualityProfilesSetDefaultCommand command)
        {
            IRestParameters restParameters = command.Parameters();
            restClient.SetPath(@"qualityprofiles/set_default").Post(restParameters);
        }
    }
}
