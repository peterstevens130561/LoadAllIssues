using PeterSoft.SonarQube.Connector;
using PeterSoft.SonarQube.Connector.Services;
using System;

namespace Templates
{
    class Program
    {
        static void Main(string[] args)
        {
            var connector = new SonarQubeConnector();
            var session = connector.CreateSession();
            session.ConnectWithToken(args[0], args[1]);
            var templatesService = session.CreateService<IPermissionsSearchTemplateService>();
            var templates = templatesService.Execute();
            Console.WriteLine(templates);
        }
    }
}
