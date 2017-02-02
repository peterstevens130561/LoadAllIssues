using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Commands;
using PeterSoft.SonarQubeConnector.Client;

namespace PeterSoft.SonarQubeConnector.Commands
{
    public class IssueAssignCommand : ParametersBase,IIssueAssignCommand
    {
        public IssueAssignCommand(IRestParameters restParameters) : base(restParameters)
        {
        }

        public IIssueAssignCommand SetIssue(string issue) 
        {
            SetParameter(@"issue", issue);
            return this;
        }

        public IIssueAssignCommand SetAssignee(string assignee)
        {
            SetParameter(@"asignee", assignee);
            return this;
        }

    }
}
