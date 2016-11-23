using SonarQube.API.Logic;
using SonarQube.API.Services;
using System;
using System.Text;

namespace Dashboard
{
    internal class SonarDashboard
    {
        private string url;
        private string username;
        private string password;

        public SonarDashboard()
        {
        }



        internal void Connect(string url, string username, string password)
        {
            this.url = url;
            this.username = username;
            this.password = password;
        }

        internal string Build()
        {
            StringBuilder sb = new StringBuilder();
            using (var webClient = new System.Net.WebClient())
            {
                var restQuerier = new RestGetter(webClient);
                restQuerier.Connect(url, username, password);
                var factory = new SonarQubeServiceFactory(restQuerier);
                var resourcesService = factory.CreateService<IResourcesService>();
                resourcesService.Parameters.SetScope("PRJ");
                var resources=resourcesService.Execute();

                var measuresService = factory.CreateService<IComponentMeasuresService>();
                measuresService.Parameters.SetMetricKeys("sqale_rating,reliability_rating,alert_status,security_rating");
                foreach(var resource in resources)
                {
                    measuresService.Parameters.SetComponentKey(resource.Key);
                    var metrics = measuresService.Execute();
                    foreach(var measure in metrics.Component.Measures)
                    {
                        sb.AppendLine(Log(metrics.Component.Key, measure.Metric, "Now", measure.Value));
                        if (measure.Periods != null)
                        {
                            foreach (var period in measure.Periods)
                            {
                                sb.AppendLine(Log(metrics.Component.Key, measure.Metric, period.Index.ToString(), period.Value));
                            }
                        }
                    }


                }
            }
            return sb.ToString();
        }

        private string Log(string key, string metric, string period, string value)
        {
            return key + "|" + metric + "|" + period + "|" + value;
        }
    
    }
}