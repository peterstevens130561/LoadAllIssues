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
    class PermissionsCreateTemplateCommand : ParametersBase, IPermissionsCreateTemplateCommand
    {
        public PermissionsCreateTemplateCommand(IRestParameters restParameters) : base(restParameters)
        {
        }

        public IPermissionsCreateTemplateCommand SetDescription(string description)
        {
            SetParameter(@"description", description);
            return this;
        }

        public IPermissionsCreateTemplateCommand SetName(string name)
        {
            SetParameter(@"name", name);
            return this;
        }

        public IPermissionsCreateTemplateCommand SetProjectKeyPattern(string projectKeyPattern)
        {
            SetParameter(@"projectKeyPattern", projectKeyPattern);
            return this;
        }
    }
}
