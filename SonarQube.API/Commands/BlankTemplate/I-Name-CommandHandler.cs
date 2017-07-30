using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands;
using PeterSoft.SonarQube.Connector.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.CommandHandlers
{
    internal class _Name_CommandHandler : ICommandHandler<_Name_Command>
    {
        private readonly RestClient restClient; 

        public _Name_CommandHandler(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public void Execute(_Name_Command command)
        {
            IRestParameters restParameters = command.Parameters();
            restClient.SetPath(@_PATH_).Post(restParameters);

        }
    }
}
