using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQube.Connector.Client;

namespace PeterSoft.SonarQube.Connector.Services
{
    class IssuesTagsService : ServiceBase<IssuesTagsServiceReponse>, IIssuesTagsService
    {
        public IssuesTagsService(IRestClient restClient, IRestParameters restParameters) : base(restClient, restParameters, @"issues/tags")
        {

        }

        public IIssuesTagsService SetPattern(string pattern)
        {
            SetParameter(@"q", pattern);
            return this;
        }

        public IIssuesTagsService SetSize(int size)
        {
            SetParameter(@"ps", size);
            return this;
        }


        public new IList<String> Execute()
        {
            var response = base.Execute();
            return response.Tags;

        }


    }

    class IssuesTagsServiceReponse
    {
        public IList<String> Tags { get; set; }
    }
}
