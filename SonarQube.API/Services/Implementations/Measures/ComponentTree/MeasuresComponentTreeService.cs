
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

    }

    //TODO: Need to find a nice way to include the BaseComponent in the return. 
    public class MeasuresComponentTreePage : Page<Component>
    {

        public IList<Component> Components { get; set; }
        public BaseComponent BaseComponent { get; set; }

        public override IList<Component> Items
        {
            get
            {
                return Components;
            }
        }
    }
}
