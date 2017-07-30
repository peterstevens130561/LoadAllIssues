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
    public class IssuesAssignCommand : ParametersBase,IIssuesAssignCommand
    {
        public IssuesAssignCommand(IRestParameters restParameters) : base(restParameters)
        {
        }

        public IIssuesAssignCommand SetIssue(string issue) 
        {
            SetParameter(@"issue", issue);
            return this;
        }

        public IIssuesAssignCommand SetAssignee(string assignee)
        {
            SetParameter(@"asignee", assignee);
            return this;
        }

    }
}
