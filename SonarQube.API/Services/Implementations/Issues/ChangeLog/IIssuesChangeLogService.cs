using PeterSoft.SonarQube.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IIssuesChangelogService : IExecuteService<IList<Changelog>>
    {
        /// <summary>
        /// Specifiy the key of the issue.
        /// See for instance issues/search to get the key
        /// </summary>
        /// <param name="key">uuniqueid (mandatory)</param>
        /// <returns></returns>
        IIssuesChangelogService SetIssue(string key) ;
    }
}
