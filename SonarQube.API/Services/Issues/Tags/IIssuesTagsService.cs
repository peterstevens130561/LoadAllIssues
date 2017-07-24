using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IIssuesTagsService : IExecuteService<IList<String>>
    {
        /// <summary>
        /// Set max size of list to return
        /// </summary>
        /// <param name="size">integer</param>
        /// <returns></returns>
        IIssuesTagsService SetSize(int size);
        /// <summary>
        /// Pattern to match
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        IIssuesTagsService SetPattern(string pattern); 
    }
}
