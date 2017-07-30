

using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands;

namespace PeterSoft.SonarQube.Connector.Commands.Factory
{
    internal interface ICommandFactory
    {
        T CreateCommand<T>(ICredentials credentials) where T : ICommand;

        ICommandHandler<T> CreateHandler<T>(T command) where T : ICommand;

    }


}