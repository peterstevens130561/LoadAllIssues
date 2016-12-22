using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Infrastructure.Commands
{
    public interface ICommandBus
    {
        void Register<T1, T2>();
        void Submit<T>(T command) where T : ICommand;
    }
}
