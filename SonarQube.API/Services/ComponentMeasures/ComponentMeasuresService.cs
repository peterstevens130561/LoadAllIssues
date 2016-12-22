
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Models;
using PeterSoft.SonarQubeConnector.Services;
using System;

namespace PeterSoft.SonarQubeConnector.Services
{
     internal class ComponentMeasuresService :  ServiceBase<ComponentMeasures> , IComponentMeasuresService
    {

        public ComponentMeasuresService(RestClient restGetter, IRestParameters restParameters) : base(restGetter, "measures/component")
        {
        }
       public IComponentMeasuresService SetComponentId(string value)
        {
            SetParameter("componentId", value);
            return this;
        }
        public IComponentMeasuresService SetComponentKey(string componentKey)
        {
            SetParameter("componentKey", componentKey);
            return this;
        }


        public IComponentMeasuresService SetMetricKeys(string metricKeys)
        {
            SetParameter("metricKeys", metricKeys);
            return this;
        }
    }

    }
