using SonarQube.API.Logic;
using SonarQube.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class Program
    {
        private Program()
        {

        }
        static void Main(string[] args)
        {
            //var servicesFactory = new SonarQubeServiceFactory(restGetter);
            var dashboard = new SonarDashboard();
            dashboard.Connect(args[0], args[1], args[2]);
            Console.WriteLine(dashboard.Build());
        }
    }
}
