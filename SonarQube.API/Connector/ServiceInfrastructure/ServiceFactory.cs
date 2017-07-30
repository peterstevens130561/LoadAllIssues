using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Services;
using System;
using System.Collections.Generic;


namespace PeterSoft.SonarQube.Connector.Infrastructure.Services
{
    internal class ServiceFactory : IServiceFactory
    {
        private readonly RestClient restGetter;
        private readonly Dictionary<Type,Type> servicesMap = new Dictionary<Type,Type>();
        public ServiceFactory(RestClient restGetter)
        {
            this.restGetter = restGetter;
        }

        public IServiceFactory Register<interfaceType, ImplementationType>() where interfaceType : IService where ImplementationType: IService
        {
            servicesMap.Add(typeof(interfaceType), typeof(ImplementationType));
            return this;
        }

        public TType CreateService<TType>(ICredentials credentials) where TType : IService
        {

            restGetter.SetCredentials(credentials);
            return CreateService<TType>(restGetter, new RestParameters());
        }

        public TService CreateService<TService>(IRestClient restClient, IRestParameters restParameters) where TService : IService
        {

            if (!servicesMap.ContainsKey(typeof(TService)))
            {
                throw new ArgumentException(@"unsupported type" + typeof(TService).FullName);
            }
            var concrete = servicesMap[typeof(TService)];
            return (TService)Activator.CreateInstance(concrete, restClient, restParameters);
        }
    }
}
