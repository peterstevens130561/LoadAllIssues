
using System.Text;
using PeterSoft.SonarQubeConnector;
using PeterSoft.SonarQubeConnector.Services;

namespace Dashboard
{
    internal class SonarDashboard
    {
        private ISession session;


        public SonarDashboard(ISession session)
        {
            this.session = session;
        }


        internal string Build()
        {
            StringBuilder sb = new StringBuilder();
                var resourcesService = session.CreateService<IResourcesService>();
                resourcesService.SetScope("PRJ");
                var resources=resourcesService.Execute();

                var measuresService = session.CreateService<IComponentMeasuresService>();
                measuresService.SetMetricKeys(@"sqale_rating,reliability_rating,alert_status,security_rating");
                foreach(var resource in resources)
                {
                    measuresService.SetComponentKey(resource.Key);
                    var metrics = measuresService.Execute();
                    foreach(var measure in metrics.Component.Measures)
                    {
                        sb.AppendLine(Log(metrics.Component.Key, measure.Metric, @"Now", measure.Value));
                        if (measure.Periods != null)
                        {
                            foreach (var period in measure.Periods)
                            {
                                sb.AppendLine(Log(metrics.Component.Key, measure.Metric, period.Index.ToString(), period.Value));
                            }
                        }
                    }


                }
            return sb.ToString();
        }

        private string Log(string key, string metric, string period, string value)
        {
            return key + @"|" + metric + @"|" + period + @"|" + value;
        }
    
    }
}