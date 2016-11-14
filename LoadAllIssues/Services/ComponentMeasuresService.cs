using LoadAllIssues.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadAllIssues.Logic
{
    public  class ComponentMeasuresService : SonarQubeServiceBase<ComponentMeasures>
    {
        public ComponentMeasuresService(RestGetter restGetter) : base(restGetter, "measures/component")
        {
        }

        public ComponentMeasuresService SetComponentId(string value)
        {
            SetParameter("componentId", value);
            return this;
        }
        public ComponentMeasuresService SetComponentKey(String componentKey)
        {
            SetParameter("componentKey", componentKey);
            return this;
       }


        public ComponentMeasuresService SetMetricKeys(string metricKeys)
        {
            SetParameter("metricKeys", metricKeys);
            return this;
        }

    }
}
