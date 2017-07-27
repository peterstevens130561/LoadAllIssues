using PeterSoft.SonarQube.Connector.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQube.Connector.Models;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.API.Logic;

namespace PeterSoft.SonarQube.Connector.Commands
{
    class PermissionsApplyTemplateCommand : ParametersBase, IPermissionsApplyTemplateCommand
    {
        public PermissionsApplyTemplateCommand(IRestParameters restParameters) : base(restParameters)
        {
        }

        public IPermissionsApplyTemplateCommand SetProjectId(string projectId)
        {
            SetParameter(@"projectId", projectId);
            return this;
        }

        public IPermissionsApplyTemplateCommand SetProjectKey(string projectKey)
        {
            SetParameter(@"projectKey", projectKey);
            return this;
        }

        public IPermissionsApplyTemplateCommand SetTemplateId(string templateId)
        {
            SetParameter(@"templateId", templateId);
            return this;
        }

        public IPermissionsApplyTemplateCommand SetTemplateName(string templateName)
        {
            SetParameter(@"templateName", templateName);
            return this;
        }
    }
}
