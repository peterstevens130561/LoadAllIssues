

namespace PeterSoft.SonarQube.Connector.Commands
{
    public interface IPermissionsBulkApplyTemplateCommand : ICommand
    {
        /// <summary>
        /// Limit search to:
        /// <list type="-">
        /// project names that contain the supplied string
        /// project keys that are exactly the same as the supplied string
        /// </list>
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IPermissionsBulkApplyTemplateCommand SetFilter(string filter);

        /// <summary>
        /// Project qualifier. Filter the results with the specified qualifier. Possible values are:
        ///DEV - Developers
        ///TRK - Projects
        /// VW - Views
        /// </summary>
        /// <param name="qualifier"></param>
        /// <returns></returns>
        IPermissionsBulkApplyTemplateCommand SetQualifier(string qualifier);
        IPermissionsBulkApplyTemplateCommand SetTemplateId(string templateId);
        IPermissionsBulkApplyTemplateCommand SetTemplateName(string templateName);

    }
}