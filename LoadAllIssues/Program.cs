using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SonarQube.API.Utilities;
using SonarQube.API.Logic;
using SonarQube.API.Services;
using SonarQube.API.Model;

namespace LoadAllIssues
{
    class Program
    {
        private Program()
        {

        }
        static void Main(string[] args)
        {

            var webClient = new WebClient();
            var restQuerier = new RestGetter(webClient);
            restQuerier.Connect(args[1], args[2], args[3]);
            var serviceFactory = new SonarQubeServiceFactory(restQuerier);
            var projectsIndexService = serviceFactory.CreateService<IProjectsIndexService>();
            var projects = projectsIndexService.Execute();
            var listedRules = new List<String>();
            var rules = new RulesSearchService(restQuerier).SetRepositories("fxcop,csharpsquid").Execute();
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
                var issues= new IssuesSearchService(restQuerier).SetStatuses("OPEN,REOPENED").SetProjectKeys(project.K).Execute();
                foreach (var issue in issues)
                {
                    if (!listedRules.Contains(issue.Rule)) {
                        var rule = new RulesShowService(restQuerier).SetKey(issue.Rule).Execute().Rule;

                        listedRules.Add(issue.Rule);
                    sb.AppendLine(project.K + "|" + issue.Rule + "|" + issue.Severity + "|" + rule.Name + "|" + EffortConversion.ConvertToMin(issue.Effort));
                }
                }

            }
            File.WriteAllText("issues.csv", sb.ToString());

        }
    }


}
