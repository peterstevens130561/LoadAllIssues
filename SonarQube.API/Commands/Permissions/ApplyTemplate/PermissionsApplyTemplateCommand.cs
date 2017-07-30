
using PeterSoft.SonarQube.Connector.Client;

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
