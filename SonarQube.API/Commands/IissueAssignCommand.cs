using PeterSoft.SonarQubeConnector.Infrastructure.Commands;

namespace PeterSoft.SonarQubeConnector.Commands
{
    public interface IIssueAssignCommand : ICommand
    {
        /// <summary>
        /// set issue to assign assignee to (required)
        /// </summary>
        /// <param name="issue">key of issue</param>
        /// <returns></returns>
        IIssueAssignCommand SetIssue(string issue);
        /// <summary>
        /// set assignee to assign issue to (required)
        /// </summary>
        /// <param name="assignee">user</param>
        /// <returns></returns>
        IIssueAssignCommand SetAssignee(string assignee);

    }
}