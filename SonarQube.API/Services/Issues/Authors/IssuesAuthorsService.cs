using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Models;

namespace PeterSoft.SonarQube.Connector.Services
{
    class IssuesAuthorsService : ServiceBase<IssuesAuthorsServiceResponse>,IIssuesAuthorsService
    {
        public IssuesAuthorsService(IRestClient restClient, IRestParameters restParameters) : base(restClient, restParameters, @"issues/authors")
        {
        }

        public IIssuesAuthorsService SetPattern(string pattern)
        {
            SetParameter("q", pattern);
            return this;
        }

        public IIssuesAuthorsService SetSize(int size)
        {
            SetParameter("ps", size);
            return this;
        }

        public new IList<String> Execute()
        {
            var response = base.Execute();
            return response.Authors;
        }
    }

    /// <summary>
    /// To mediate between the response, and the list.
    /// </summary>
    internal class IssuesAuthorsServiceResponse
    {
        public List<string> Authors { get; set; }
    }
}
