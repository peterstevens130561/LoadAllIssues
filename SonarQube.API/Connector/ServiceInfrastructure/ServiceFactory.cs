using PeterSoft.SonarQubeConnector.API.Logic;
using System;
using System.Collections.Generic;


namespace PeterSoft.SonarQubeConnector.Infrastructure.Services
{
    internal class ServiceFactory : IServiceFactory
    {
        private readonly RestClient restGetter;
        private Dictionary<Type,Type> servicesMap = new Dictionary<Type,Type>();
        public ServiceFactory(RestClient restGetter)
        {
            this.restGetter = restGetter;
        }

        public IServiceFactory Register<interfaceType, ImplementationType>()
        {
            servicesMap.Add(typeof(interfaceType), typeof(ImplementationType));
            return this;
        }

        public TType CreateService<TType>(ICredentials credentials)
        {
            restGetter.Connect(credentials);
            if(!servicesMap.ContainsKey(typeof(TType)))
            {
                throw new ArgumentException("unsupported type");
            }
            var concrete = servicesMap[typeof(TType)];
            return (TType)Activator.CreateInstance(concrete, restGetter,new RestParameters());
        }
    }
}
