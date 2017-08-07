using PeterSoft.SonarQube.Connector.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQube.Connector.Models;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Client;

namespace PeterSoft.SonarQube.Connector.Commands
{
    class QualityProfilesRenameCommand : ParametersBase, IQualityProfilesRenameCommand
    {
        public QualityProfilesRenameCommand(IRestParameters restParameters) : base(restParameters)
        {
        }







    }
}
