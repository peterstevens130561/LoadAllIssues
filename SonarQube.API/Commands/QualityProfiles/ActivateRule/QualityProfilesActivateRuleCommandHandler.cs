using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands;
using PeterSoft.SonarQube.Connector.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
