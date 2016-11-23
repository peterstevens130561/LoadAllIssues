using SonarQube.API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarQube.API.Services
{
    internal class ComponentMeasuresParameters : RestParameters, IComponentMeasuresParameters
    {
        internal ComponentMeasuresParameters()
        { 
   
        }
        public IComponentMeasuresParameters SetComponentId(string value)
        {
            SetParameter("componentId", value);
            return this;
        }
        public IComponentMeasuresParameters SetComponentKey(string componentKey)
        {
            SetParameter("componentKey", componentKey);
            return this;
        }


        public IComponentMeasuresParameters SetMetricKeys(string metricKeys)
        {
            SetParameter("metricKeys", metricKeys);
            return this;
        }
    }
}
