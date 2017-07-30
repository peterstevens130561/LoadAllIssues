

using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands;

namespace PeterSoft.SonarQube.Connector.Commands.Bus
{
    internal interface ICommandBus
    {
        T CreateCommand<T>(ICredentials credentials) where T : ICommand;

        void Execute<T>(T command) where T : ICommand;
        /// <summary>
        /// Register a command interface and its implementation
        /// </summary>
        /// <typeparam name="commandInterface"></typeparam>
        /// <typeparam name="commandImplementationType"></typeparam>
        /// <returns></returns>
    }


}