using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Commands.Bus
{
    interface ICommandHandlerFactory
    {
        void Register<T1, T2>();
        T Create<T>(T command) where T : ICommand;
    }
}
