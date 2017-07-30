using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands.Factory;

namespace PeterSoft.SonarQube.Connector.Commands.Bus
{
    class CommandBus : ICommandBus
    {
        private readonly ICommandFactory commandFactory;
        public CommandBus(ICommandFactory commandFactory) 
        {
            this.commandFactory = commandFactory;
  
        }

        public T CreateCommand<T>(ICredentials credentials) where T : ICommand
        {
            return commandFactory.CreateCommand<T>(credentials);
        }

        public void Execute<T>(T command) where T : ICommand
        {
            var handler = commandFactory.CreateHandler(command);
            handler.Execute(command);
        }
    }
    }
