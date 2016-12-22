using PeterSoft.SonarQubeConnector;
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Services;
using PeterSoft.SonarQubeConnector.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExtractProjectIssues
{
    class Program
    {
        static void Main(string[] args)
        {
            var connector = new SonarQubeConnector();
            var session = connector.CreateSession();
            session.Connect(args[0], args[1], args[2]);
            var projectsService = session.CreateQueryService<IProjectsIndexService>();
            var projects = projectsService.Execute();
            var issuesSearchService = session.CreateQueryService<IIssuesSearchService>();
            issuesSearchService.SetStatuses("OPEN");
            Console.WriteLine("Project|Message|Component|Line|Rule|Severity|");
            foreach (var project in projects)
            {
                issuesSearchService.SetProjectKeys(project.K);
                var issues = issuesSearchService.Execute();
                foreach (var issue in issues)
                {
                    Console.WriteLine(project.Nm + "|" + issue.Message + "|" + issue.Component + "|" + issue.Line + "|" + issue.Rule + "|" + issue.Severity);
                }
            }



        }
    }
}
