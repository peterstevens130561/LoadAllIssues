
using PeterSoft.SonarQube.Connector.API.Logic;
using PeterSoft.SonarQube.Connector.Models;
using PeterSoft.SonarQube.Connector.Services;
using System;

namespace PeterSoft.SonarQube.Connector.Services
{
     internal class ComponentMeasuresService :  ServiceBase<ComponentMeasures> , IComponentMeasuresService
    {

        public ComponentMeasuresService(RestClient restGetter, IRestParameters restParameters) : base(restGetter, restParameters,"measures/component")
        {
        }
       public IComponentMeasuresService SetComponentId(string value)
        {
            SetParameter(@"componentId", value);
            return this;
        }
        public IComponentMeasuresService SetComponentKey(string componentKey)
        {
            SetParameter(@"componentKey", componentKey);
            return this;
        }


        public IComponentMeasuresService SetMetricKeys(string metricKeys)
        {
            SetParameter(@"metricKeys", metricKeys);
            return this;
        }
    }

    }
