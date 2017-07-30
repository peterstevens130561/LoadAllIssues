
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Infrastructure.Commands;

namespace PeterSoft.SonarQube.Connector.Commands
{
    internal class IssuesAssignCommandHandler : ICommandHandler<IssuesAssignCommand>
    {
        private readonly RestClient restClient; 

        public IssuesAssignCommandHandler(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public void Execute(IssuesAssignCommand command)
        {
            IRestParameters restParameters = command.Parameters();
            restClient.SetPath(@"issues/assign").Post(restParameters);

        }
    }
}
