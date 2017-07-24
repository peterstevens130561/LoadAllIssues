using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQube.Connector.API.Logic;
using PeterSoft.SonarQube.Connector.Commands;
using PeterSoft.SonarQube.Connector.Client;

namespace PeterSoft.SonarQube.Connector.Commands
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
