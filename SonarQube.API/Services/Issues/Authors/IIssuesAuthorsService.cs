using PeterSoft.SonarQube.Connector.Models;
using PeterSoft.SonarQube.Connector.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Services
{
    /// <summary>
    /// see web_api/api/issues
    /// </summary>
    public interface IIssuesAuthorsService : IExecuteService<IList<String>>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size">The size of the list to return</param>
        /// <returns></returns>
        IIssuesAuthorsService SetSize(int size);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern">A pattern to match SCM accounts against</param>
        /// <returns></returns>
        IIssuesAuthorsService SetPattern(string pattern);
    }
}
