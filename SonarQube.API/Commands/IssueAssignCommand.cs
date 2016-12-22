using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Commands;

namespace PeterSoft.SonarQubeConnector.Commands
{
    public class IssueAssignCommand : IIssueAssignCommand
    {
        private readonly IRestParameters restParameters = new RestParameters();

        public IIssueAssignCommand SetIssue(string issue) 
        {
            restParameters.SetParameter("issue", issue);
            return this;
        }

        public IIssueAssignCommand SetAssignee(string assignee)
        {
            restParameters.SetParameter("asignee", assignee);
            return this;
        }

        internal IRestParameters Parameters()
        {
            return restParameters;
        }
    }
}
