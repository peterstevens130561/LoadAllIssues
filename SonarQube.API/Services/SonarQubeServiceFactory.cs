using SonarQube.API.Logic;
using SonarQube.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarQube.API.Services
{
    public class SonarQubeServiceFactory 
    {
        private readonly RestGetter restGetter;
        private Dictionary<Type,Type> servicesMap = new Dictionary<Type,Type>();
        public SonarQubeServiceFactory(RestGetter restGetter)
        {
            this.restGetter = restGetter;
            Register<IComponentMeasuresParameters,ComponentMeasuresService>();
            Register<IProjectsIndexService, ProjectsIndexService>();
            Register<IRulesShowService, RulesShowService>();
            Register<IResourcesService, ResourcesService>();
        }

        private void Register<interfaceType, ImplementationType>()
        {
            servicesMap.Add(typeof(interfaceType), typeof(ImplementationType));
        }

        public TType CreateService<TType>()
        {
            if(!servicesMap.ContainsKey(typeof(TType)))
            {
                throw new ArgumentException("unsupported type");
            }
            var concrete = servicesMap[typeof(TType)];
            return (TType)Activator.CreateInstance(concrete, restGetter);
        }
    }
}
