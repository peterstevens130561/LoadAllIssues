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
    internal class IssueAssignCommandHandler : ICommandHandler<IssueAssignCommand>
    {
        private readonly RestClient restClient; 

        public IssueAssignCommandHandler(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public void Execute(IssueAssignCommand command)
        {
            IRestParameters restParameters = command.Parameters();
            restClient.SetPath(@"issues/assign").Post(restParameters);

        }
    }
}
