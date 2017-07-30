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
    class PermissionsBulkApplyTemplateCommand : ParametersBase, IPermissionsBulkApplyTemplateCommand
    {
        public PermissionsBulkApplyTemplateCommand(IRestParameters restParameters) : base(restParameters)
        {
        }

        public IPermissionsBulkApplyTemplateCommand SetFilter(string filter)
        {
            SetParameter(@"q", filter);
            return this;
        }

        public IPermissionsBulkApplyTemplateCommand SetQualifier(string qualifier)
        {
            SetParameter(@"qualifier", qualifier);
            return this;
        }

        public IPermissionsBulkApplyTemplateCommand SetTemplateId(string templateId)
        {
            SetParameter(@"templateId", templateId);
            return this;
        }

        public IPermissionsBulkApplyTemplateCommand SetTemplateName(string templateName)
        {
            SetParameter(@"templateName", templateName);
            return this;
        }
    }
}
