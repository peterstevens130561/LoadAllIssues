using PeterSoft.SonarQube.Connector.Infrastructure.Commands;

namespace PeterSoft.SonarQube.Connector.Commands
{
    public interface IPermissionsDeleteTemplateCommand : ICommand
    {
        /// <summary>
        /// (optional)
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        IPermissionsDeleteTemplateCommand SetTemplateId(string templateId);
        /// <summary>
        /// (optional)
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>
        IPermissionsDeleteTemplateCommand SetTemplateName(string templateName);
    }
}