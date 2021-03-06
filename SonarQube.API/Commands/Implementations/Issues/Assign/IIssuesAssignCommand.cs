﻿

namespace PeterSoft.SonarQube.Connector.Commands
{
    public interface IIssuesAssignCommand : ICommand
    {
        /// <summary>
        /// set issue to assign assignee to (required)
        /// </summary>
        /// <param name="issue">key of issue</param>
        /// <returns></returns>
        IIssuesAssignCommand SetIssue(string issue);
        /// <summary>
        /// set assignee to assign issue to (required)
        /// </summary>
        /// <param name="assignee">user</param>
        /// <returns></returns>
        IIssuesAssignCommand SetAssignee(string assignee);

    }
}