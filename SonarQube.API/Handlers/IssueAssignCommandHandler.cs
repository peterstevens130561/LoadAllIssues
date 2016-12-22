using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Commands;
using PeterSoft.SonarQubeConnector.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.CommandHandlers
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
            restClient.SetPath("issues/assign").Post(restParameters);

        }
    }
}
