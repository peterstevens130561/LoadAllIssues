using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PeterSoft.SonarQubeConnector.API.Utilities;
using PeterSoft.SonarQubeConnector.Services;
using PeterSoft.SonarQubeConnector.Models;
using PeterSoft.SonarQubeConnector;

namespace LoadAllIssues
{
    class Program
    {
        private Program()
        {

        }
        static void Main(string[] args)
        {
            var connector = new SonarQubeConnector();
            var session = connector.CreateSession();
            session.Connect(args[0], args[1], args[2]);

            var projectsIndexService = session.CreateQueryService<IProjectsIndexService>();
            var projects = projectsIndexService.Execute();
            var listedRules = new List<String>();
            var rulesSearchService = session.CreateQueryService<IRulesSearchService>();
            rulesSearchService.SetRepositories("fxcop,csharpsquid");
            var rules = rulesSearchService.Execute();
            StringBuilder sb = new StringBuilder(4096);
            foreach(Rule rule in rules)
            {
                sb.AppendLine(rule.Key + "|" + rule.Name + "|" + rule.Severity + "|" +  rule.Type + "|" + 
                    rule.DefaultRemFnType +  "|" + EffortConversion.ConvertToMin(rule.DefaultRemFnBaseEffort) + "|" + EffortConversion.ConvertToMin(rule.DefaultRemFnGapMultiplier));
            }
            File.WriteAllText("baseline.csv",sb.ToString());
            sb.Clear();
            foreach (Project project in projects)
            {
                var issuesSearchService = session.CreateQueryService<IIssuesSearchService>();
                var issues=issuesSearchService.SetStatuses("OPEN,REOPENED").SetProjectKeys(project.K).Execute();
                foreach (var issue in issues)
                {
                    if (!listedRules.Contains(issue.Rule)) {
                        var rulesShowService = session.CreateQueryService<IRulesShowService>();
                        var rule = rulesShowService.SetKey(issue.Rule).Execute().Rule;

                        listedRules.Add(issue.Rule);
                    sb.AppendLine(project.K + "|" + issue.Rule + "|" + issue.Severity + "|" + rule.Name + "|" + EffortConversion.ConvertToMin(issue.Effort));
                }
                }

            }
            File.WriteAllText("issues.csv", sb.ToString());

        }
    }


}
