using PeterSoft.SonarQube.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Services
{
    /// <summary>
    /// List permission templates.
    /// It requires to be authenticated
    /// </summary>
    public interface IPermissionsSearchTemplateService  : IExecuteService<PermissionTemplates>
    {
        /// <summary>
        /// Limit search to permission template names that contain the supplied string.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IPermissionsSearchTemplateService SetFilter(string filter);
    }
}
