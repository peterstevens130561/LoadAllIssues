using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQubeConnector.Models;
using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Services
{
    class IssuesChangelogService : ServiceBase<IssuesChangeLogServiceResponse>, IIssuesChangelogService
    {
        public IssuesChangelogService(IRestClient restClient, IRestParameters restParameters) : base(restClient, restParameters, @"issues/changelog")
        {
        }
        public IIssuesChangelogService SetIssue(string key)
        {
            SetParameter("issue", key);
            return this;
        }

        public new IList<Changelog> Execute()
        {
            var response = base.Execute();
            return response.Changelog;
        }
    }

    public class IssuesChangeLogServiceResponse
    {
        public List<Changelog> Changelog { get; set; }
    }

}
