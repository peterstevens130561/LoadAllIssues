using PeterSoft.SonarQube.Connector;
using PeterSoft.SonarQube.Connector.Services;

namespace ExtractProjectIssues
{
    class Program
    {
        static void Main(string[] args)
        {
            var connector = new SonarQubeConnector();
            var session = connector.CreateSession();
            session.ConnectWithToken(args[0], args[1]);
            var projectsService = session.CreateService<IProjectsIndexService>();
            projectsService.SetKey("Transformer-Bhi.Esie.TooLink");
            var projects = projectsService.Execute();
            var issuesSearchService = session.CreateService<IIssuesSearchService>();
            issuesSearchService.SetStatuses(@"OPEN");
            using (var writer = new System.IO.StreamWriter("issues.csv"))
            {
                writer.WriteLine(@"Project|Message|Component|Line|Rule|Severity|");
                foreach (var project in projects)
                {
                    issuesSearchService.SetProjectKeys(project.K);
                    var issues = issuesSearchService.Execute();
                    foreach (var issue in issues)
                    {
                        writer.WriteLine(project.Nm + @"|" + issue.Message + @"|" + issue.Component + @"|" + issue.Line + @"|" + issue.Rule + @"|" + issue.Severity);
                    }
                }
            }
        }
    }
}
