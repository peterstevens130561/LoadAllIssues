
using PeterSoft.SonarQubeConnector.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Infrastructure.Commands{

    internal class CommandBus : ICommandBus
    {
        private readonly Dictionary<Type, Type> handlerMap = new Dictionary<Type, Type>();
        private readonly RestClient restGetter;

        public CommandBus(RestClient restGetter)
        {
            this.restGetter = restGetter;
        }

        /// <summary>
        /// execute a command
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="command"></param>
        public void Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (!handlerMap.ContainsKey(typeof(TCommand)))
            {
                throw new ArgumentException("unsupported type");
            }
            var handlerType = handlerMap[typeof(TCommand)];
            var handler = (ICommandHandler<TCommand>)Activator.CreateInstance(handlerType);
            handler.Execute(command);
        }

        /// <summary>
        /// Register command handler with the command
        /// </summary>
        /// <typeparam name="TCommand">command</typeparam>
        /// <typeparam name="THandler">handler</typeparam>
        /// <returns></returns>
        public ICommandBus Register<TCommand, THandler>() where TCommand : ICommand where THandler : ICommandHandler<TCommand>
        {
            handlerMap.Add(typeof(TCommand), typeof(THandler));
            return this;
        }

        //

        void ICommandBus.Register<Tcommand, Thandler>()
        {
            handlerMap.Add(typeof(Tcommand), typeof(Thandler));
        }
    }
}
