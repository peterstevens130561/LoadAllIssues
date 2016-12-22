

using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Infrastructure.Commands
{
    internal interface ICommandFactory
    {
        T CreateCommand<T>(ICredentials credentials) where T : ICommand;

        /// <summary>
        /// Register a command interface and its implementation
        /// </summary>
        /// <typeparam name="TInferface"></typeparam>
        /// <typeparam name="VImplementation"></typeparam>
        /// <returns></returns>
        ICommandFactory Register<TInferface, VImplementation>() where TInferface : ICommand where VImplementation : ICommand;
    }


}