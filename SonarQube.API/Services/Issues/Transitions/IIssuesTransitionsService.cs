

using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    /// <summary>
    /// provides the transitions from the current status of the specified issue
    /// </summary>
    public interface IIssuesTransitionsService : IExecuteService<IList<string>>
    {
        /// <summary>
        /// set the key of the issue 
        /// </summary>
        /// <param name="issue"></param>
        /// <returns></returns>
        IIssuesTransitionsService SetIssue(string issue);
    }
}
