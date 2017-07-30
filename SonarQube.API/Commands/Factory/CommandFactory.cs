
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands;
using System;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Commands.Factory
{
    class CommandFactory : ICommandFactory
    {
        private readonly Dictionary<Type, Type> commandMap = new Dictionary<Type, Type>();
        private readonly Dictionary<Type, Type> handlerMap = new Dictionary<Type, Type>();
        private readonly IRestClient restClient;

        public CommandFactory(IRestClient restClient)
        {
            this.restClient = restClient;

            Register<IIssuesAssignCommand, IssuesAssignCommand, IssuesAssignCommandHandler>();
            Register<IDevCockpitRunCommand, DevCockpitRunCommand, DevCockpitRunCommandHandler>();
            Register<IActivateRuleInQualityProfileCommand, QualityProfilesActivateRuleCommand, ActivateRuleInQualityProfileCommandHandler>();
            Register<IPermissionsApplyTemplateCommand, PermissionsApplyTemplateCommand, PermissionsApplyTemplateCommandHandler>();
            Register<IPermissionsBulkApplyTemplateCommand, PermissionsBulkApplyTemplateCommand, PermissionsBulkApplyTemplateCommandHandler>();
            Register<IPermissionsCreateTemplateCommand, PermissionsCreateTemplateCommand, PermissionsCreateTemplateCommandHandler>();
        }
        private void Register<interfaceType , commandType,handlerType> () 
            where interfaceType : ICommand 
            where commandType:ICommand
            where handlerType : ICommandHandler<commandType>
        {
            commandMap.Add(typeof(interfaceType), typeof(commandType));
            handlerMap.Add(typeof(commandType), typeof(handlerType));
        }

        public T CreateCommand<T>(ICredentials credentials) where T : ICommand
        {
            restClient.SetCredentials(credentials);
            if (!commandMap.ContainsKey(typeof(T)))
            {
                throw new ArgumentException(@"unsupported type");
            }
            var concrete = commandMap[typeof(T)];
            return (T)Activator.CreateInstance(concrete,new RestParameters());

        }

        public ICommandHandler<TCommand> CreateHandler<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (!handlerMap.ContainsKey(typeof(TCommand)))
            {
                throw new ArgumentException(@"unsupported type");
            }
            var handlerType = handlerMap[typeof(TCommand)];
            return (ICommandHandler<TCommand>)Activator.CreateInstance(handlerType, restClient);

        }
    }
}
