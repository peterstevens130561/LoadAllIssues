using PeterSoft.SonarQube.Connector.Infrastructure.Commands;

namespace PeterSoft.SonarQube.Connector.Commands
{
    /// <summary>
    /// Create a permission template
    /// <para>
    /// It requires administration permissions to access.
    /// </para>
    /// </summary>
    public interface IPermissionsCreateTemplateCommand : ICommand
    {
        /// <summary>
        /// Description
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        IPermissionsCreateTemplateCommand SetDescription(string description);
        /// <summary>
        /// Name of template (required)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IPermissionsCreateTemplateCommand SetName(string name);
        /// <summary>
        /// Project key pattern. Must be a valid Java regular expression (optional)
        /// </summary>
        /// <param name="projectKeyPattern"></param>
        /// <returns></returns>
        IPermissionsCreateTemplateCommand SetProjectKeyPattern(string projectKeyPattern);

    }
}