using PeterSoft.SonarQubeConnector;
using PeterSoft.SonarQubeConnector.Models;
using PeterSoft.SonarQubeConnector.Services;
using System;
using System.Linq;

namespace CompareServers
{
    class Program
    {
        private Program ()
        {

        }
        static void Main(string[] args)
        {
            var sonarQubeConnector = new SonarQubeConnector();

            var session = sonarQubeConnector.CreateSession();
            session.Connect(args[0], args[2], args[3]);
            var resourcesService = session.CreateQueryService<IResourcesService>();
            var production = resourcesService.Execute();
            resourcesService= session.CreateQueryService<IResourcesService>();
            var staging = resourcesService.Execute();
            // production is the reference, everything that has been recently analysed in there
            // should be analyzed recently in the staging.

            // if last analysis in product more than a month ago, then do not bother
            // if not found in staging, then we have an issue
            // if analysis in staging more than a week ago, then we have an issue

            foreach (Resource productionResource in production)
            {
                var inStaging = staging.FirstOrDefault(x => x.Key.Equals(productionResource.Key));
                Console.Write(productionResource.Lname);
                Console.WriteLine(" " + Status(productionResource, inStaging));

            }
            Console.WriteLine("Done");


        }


        static string Status(Resource product, Resource staging)
        {
            TimeSpan lastAnalysisProduction = DateTime.Now - product.Date;
            if (lastAnalysisProduction.Days > 20)
            {
                return @"stale";
            }
            if (staging == null)
            {
                return @"not found in staging";
            }
            var lastAnalysisStaging = DateTime.Now - staging.Date;
            if (lastAnalysisStaging.Days < 10)
            {
                return @"ok";
            }
            return @"analysed " + staging.Date + "on staging and " + product.Date + " on production";

        }
    }
}
