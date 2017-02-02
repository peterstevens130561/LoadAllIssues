using PeterSoft.SonarQubeConnector;
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Services;
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
            int a = 4;
            var connector = new SonarQubeConnector();
            var session = connector.CreateSession();
            session.Connect(args[0], args[1], args[2]);
            var dashboard = new SonarDashboard(session);
            Console.WriteLine(dashboard.Build());
        }
    }
}
