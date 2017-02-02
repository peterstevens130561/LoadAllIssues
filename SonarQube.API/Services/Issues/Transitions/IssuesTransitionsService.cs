using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Services.Issues
{
    class IssuesTransitionsService : ServiceBase<IssuesTransitionsServiceResponse>, IIssuesTransitionsService
    {
        public IssuesTransitionsService(IRestClient restClient, IRestParameters restParameters) : base(restClient, restParameters, @"issues/transitions")
        {
        }

        public IIssuesTransitionsService SetIssue(string issue)
        {
            SetParameter(@"issue", issue);
            return this;
        }

        public new IList<string> Execute()
        {
            var response = base.Execute();
            return response.Transitions;
        }
    }

    class IssuesTransitionsServiceResponse
    {
        public IList<string> Transitions { get; set; }
    }
}
