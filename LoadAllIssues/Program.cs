using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using LoadAllIssues.Model;
using LoadAllIssues.Logic;
using LoadAllIssues.Services;
using System.IO;
using SonarQube.API.Utilities;

namespace LoadAllIssues
{
    class Program
    {
        static void Main(string[] args)
        {

            var webClient = new WebClient();
            webClient.UseDefaultCredentials = false;
            webClient.Credentials = new NetworkCredential("stevpet","Al33merehvs");
            //webClient.Credentials = new NetworkCredential("admin", "admin");
            var restQuerier = new RestGetter(webClient,"http://bhidftweb01:9005");
            var projects = restQuerier.SetPath("projects").Execute<IList<Project>>(new Logic.RestParameters());
            Console.WriteLine(projects.Count);
            var listedRules = new List<String>();
            var rules = new RulesSearchService(restQuerier).SetRepositories("fxcop,csharpsquid").Execute();
            StringBuilder sb = new StringBuilder(4096);
            foreach(Rule rule in rules)
            {
                sb.AppendLine(rule.Key + "|" + rule.Name + "|" + rule.Severity + "|" +  rule.Type + "|" + 
                    rule.DefaultRemFnType +  "|" + rule.DefaultRemFnBaseEffort + "|" + rule.DefaultRemFnGapMultiplier);
            }
            File.WriteAllText("baseline.csv",sb.ToString());
            sb.Clear();
            foreach (Project project in projects)
            {
                var issues= new IssuesSearchService(restQuerier).SetStatuses("OPEN,REOPENED").SetProjectKeys(project.k).Execute();
                foreach (var issue in issues)
                {
                    if (!listedRules.Contains(issue.Rule)) {
                        var rule = new RulesShowService(restQuerier).SetKey(issue.Rule).Execute().Rule;

                        listedRules.Add(issue.Rule);
                    sb.AppendLine(project.k + "|" + issue.Rule + "|" + issue.Severity + "|" + rule.Name + "|" + EffortConversion.ConvertToMin(issue.Effort));
                }
                }

            }
            File.WriteAllText("issues.csv", sb.ToString());

        }
    }


}
