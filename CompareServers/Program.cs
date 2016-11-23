using SonarQube.API.Logic;
using SonarQube.API.Model;
using SonarQube.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CompareServers
{
    class Program
    {
        private Program ()
        {

        }
        static void Main(string[] args)
        {
            var webClient = new WebClient();
            var restQuerier = new RestGetter(webClient);
            restQuerier.Connect(args[0], args[2], args[3]);
            var factory = new SonarQubeServiceFactory(restQuerier);
            var resourcesService = factory.CreateService<IResourcesService>();
            var production = resourcesService.Execute();
            restQuerier.Connect(args[1], args[2], args[3]);
            resourcesService= factory.CreateService<IResourcesService>();
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
