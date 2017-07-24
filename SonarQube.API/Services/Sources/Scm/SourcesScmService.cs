using PeterSoft.SonarQube.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQube.Connector.API.Logic;

namespace PeterSoft.SonarQube.Connector.Services
{
    class SourcesScmService : ServiceBase<SourcesScmResponse>, ISourcesScmService
    {
        public SourcesScmService(IRestClient restClient, IRestParameters restParameters) : base(restClient, restParameters, @"sources/scm")
        {
        }

        public ISourcesScmService SetCommitsByLine(bool byLine)
        {
            SetParameter(@"commits_by_line", byLine);
            return this;
        }

        public ISourcesScmService SetFromLine(int line)
        {
            SetParameter(@"from", line);
            return this;
        }

        public ISourcesScmService SetKey(string key)
        {
            SetParameter(@"key", key);
            return this;
        }

        public ISourcesScmService SetToLine(int line)
        {
            SetParameter(@"to", line);
            return this;
        }

        public new IList<Commit> Execute()
        {
            IList<Commit> result = new List<Commit>();
            var response= base.Execute();
            foreach(var values in response.Scm)
            {
                int line = Convert.ToInt32(values[0]);
                string author = (string)values[1];
                DateTime date = Convert.ToDateTime(values[2]);
                string id = (string)values[3];

                Commit commit = new Commit(line,author,date,id);
                result.Add(commit);
            }
            return result;
        }
    }

    class SourcesScmResponse
    {
        public List<List<object>> Scm { get; set; }
    }
}
