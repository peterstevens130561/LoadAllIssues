
using PeterSoft.SonarQubeConnector;
using PeterSoft.SonarQubeConnector.Commands;
using PeterSoft.SonarQubeConnector.Models;
using PeterSoft.SonarQubeConnector.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SetCSharpWarningsToBlocker
{
    static class Program
    {
        static void Main(string[] args)
        {
            var connector = new SonarQubeConnector();
            var session = connector.CreateSession();
            session.Connect(args[0], args[1], args[2]);
            // get the CleanSweep profile
            var profilesService = session.CreateService<IQualityProfilesSearchService>();
            var activateRuleCommand = session.CreateCommand<IActivateRuleInQualityProfileCommand>();
            profilesService.SetProfileName(@"CleanSweep").SetLanguageKey(@"cs");
          
            IList<Profile> profiles = profilesService.Execute();
            var profile=profiles.FirstOrDefault(p => p.Name.Equals(@"CleanSweep"));
            var profileKey = profile.Key;
            // GEt all rules in the profile
            var rulesService = session.CreateService<IRulesSearchService>();
            rulesService.SetProfileKey(profileKey);
            IList<Rule> rules = rulesService.Execute();
            activateRuleCommand.SetProfileKey(profileKey);
            foreach (Rule rule in rules)
            {
                if (IsCompilerWarning(rule))
                {
                    Console.WriteLine(rule.HtmlDesc);
                    activateRuleCommand.SetRuleKey(rule.Key).SetSeverity(@"BLOCKER");
                    session.SubmitCommand(activateRuleCommand);
                }
            }
            Console.WriteLine(@"Done");
        }


        static Boolean IsCompilerWarning(Rule rule)
        {
            Regex pattern = new Regex(@".*CS\d\d\d\d.*");
            return pattern.IsMatch(rule.Key);
        }
    }
}
