using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.CommandHandlers
{
    internal class QualityProfilesRenameCommandHandler : ICommandHandler<QualityProfilesRenameCommand>
    {
        private readonly RestClient restClient; 

        public QualityProfilesRenameCommandHandler(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public void Execute(QualityProfilesRenameCommand command)
        {
            IRestParameters restParameters = command.Parameters();
            restClient.SetPath(@"qualityprofiles/rename").Post(restParameters);

        }
    }
}
