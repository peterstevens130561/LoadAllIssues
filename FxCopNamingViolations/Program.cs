using PeterSoft.SonarQube.Connector;
using PeterSoft.SonarQube.Connector.Models;
using PeterSoft.SonarQube.Connector.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FxCopNamingViolations
{
    class Program
    {
        static void Main(string[] args)
        {
            var connector = new SonarQubeConnector();
            var session = connector.CreateSession();
            session.Connect(args[0], args[1], args[2]);
            //var resourcesService = session.CreateService<IResourcesService>();
            //resourcesService.SetScope("PRJ");
            //var resources = resourcesService.Execute();
            var issuesSearchService = session.CreateService<IIssuesSearchService>();
            issuesSearchService.SetRules(@"fxcop:IdentifiersShouldBeCasedCorrectly");
            IList<Issue> issues = issuesSearchService.Execute();
            Regex rule = new Regex(@".* the casing of '(.*)'.*");
            var violations = new Dictionary<String, int>();
            foreach (var issue in issues)
            {
                var match= rule.Match(issue.Message);

                string wrong = @"";
                if(match.Success)
                {
                    wrong = match.Groups[1].Value;

                } else
                {
                    Console.WriteLine(issue.Message);
                }

                int count = 1;
                if(violations.ContainsKey(wrong))
                {
                    count += violations[wrong];
                    violations.Remove(wrong);
                }
                violations.Add(wrong, count);
            }
            Console.WriteLine(@"Key,Value");
            foreach(var entry in violations)
            {
                string line = String.Format(@"{0},{1}", entry.Key, entry.Value);
                Console.WriteLine(line);
            }
            Console.WriteLine(@"Done");
        }
    }
}
