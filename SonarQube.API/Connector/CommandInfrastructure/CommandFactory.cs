﻿
using PeterSoft.SonarQubeConnector.API.Logic;
using System;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Infrastructure.Commands
{
    class CommandFactory : ICommandFactory
    {
        private Dictionary<Type, Type> commandMap = new Dictionary<Type, Type>();
        private readonly IRestClient restClient;

        public CommandFactory(IRestClient restClient)
        {
            this.restClient = restClient;
        }
        public ICommandFactory Register<interfaceType , ImplementationType> () where interfaceType : ICommand where ImplementationType:ICommand
        {
            commandMap.Add(typeof(interfaceType), typeof(ImplementationType));
            return this;
        }

        public T CreateCommand<T>(ICredentials credentials) where T : ICommand
        {
            restClient.Connect(credentials);
            if (!commandMap.ContainsKey(typeof(T)))
            {
                throw new ArgumentException("unsupported type");
            }
            var concrete = commandMap[typeof(T)];
            return (T)Activator.CreateInstance(concrete,restClient);
        }
    }
}
