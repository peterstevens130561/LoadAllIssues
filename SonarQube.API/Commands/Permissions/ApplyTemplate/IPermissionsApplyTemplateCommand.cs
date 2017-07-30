

namespace PeterSoft.SonarQube.Connector.Commands
{
    public interface IPermissionsApplyTemplateCommand : ICommand
    {
        IPermissionsApplyTemplateCommand SetProjectId(string projectId);
        IPermissionsApplyTemplateCommand SetProjectKey(string projectKey);
        IPermissionsApplyTemplateCommand SetTemplateId(string templateId);
        IPermissionsApplyTemplateCommand SetTemplateName(string templateName);

    }
}