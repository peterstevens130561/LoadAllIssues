
using SonarQube.API.Logic;
using SonarQube.API.Model;
using System;

namespace SonarQube.API.Services
{
     internal class ComponentMeasuresService :  SonarQubeGetService<ComponentMeasures, IComponentMeasuresParameters> , IComponentMeasuresService
    {

        public ComponentMeasuresService(RestGetter restGetter) : base(restGetter, "measures/component", new ComponentMeasuresParameters())
        {

        }

    }
}
