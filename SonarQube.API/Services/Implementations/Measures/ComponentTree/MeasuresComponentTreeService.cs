
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;
using System;

namespace PeterSoft.SonarQube.Connector.Services
{
    internal class MeasuresComponentTreeService : PagedServiceBase<Component, MeasuresComponentTreePage>, IMeasuresComponentTreeService

    {

        public MeasuresComponentTreeService(IRestClient restGetter,IRestParameters parameters) : base(restGetter, parameters, "measures/component_tree") { }
  

        public IMeasuresComponentTreeService SetBaseComponentKey(string baseComponentKey)
        {
            SetParameter(@"baseComponentKey", baseComponentKey);
            return this;
        }

        public IMeasuresComponentTreeService SetAdditionalFields(string additionalFields)
        {
            SetParameter(@"additionalFields", additionalFields);
            return this;
        }

        public IMeasuresComponentTreeService SetBaseComponentId(string baseComponentId)
        {
            SetParameter(@"baseComponentId", baseComponentId);
            return this;
        }

        public IMeasuresComponentTreeService SetDeveloperId(string developerId)
        {
            SetParameter(@"developerId", developerId);
            return this;
        }
        public IMeasuresComponentTreeService SetDeveloperKey(string developerKey)
        {
            SetParameter(@"developerKey", developerKey);
            return this;
        }
        public IMeasuresComponentTreeService SetMetricKeys(string metricKeys)
        {
            SetParameter(@"metricKeys", metricKeys);
            return this; }
        public IMeasuresComponentTreeService SetMetricSortfilter(string metricSortFilter)
        {
            SetParameter("metricSortFilter", metricSortFilter);
            return this;
        }
        public IMeasuresComponentTreeService SetQualifiers(string qualifiers)
        {
            SetParameter("qualifiers", qualifiers);
            return this;
        }
        public IMeasuresComponentTreeService SetStrategy(string strategy)
        {
            SetParameter("strategy", strategy);
            return this;
        }

    }

    //TODO: Need to find a nice way to include the BaseComponent in the return. 
    public class MeasuresComponentTreePage : Page<Component>
    {

        public IList<Component> Components { get; set; }
        public override IList<Component> Items
        {
            get
            {
                return Components;
            }
        }
    }
}
