using PeterSoft.SonarQubeConnector.Infrastructure.Commands;

namespace PeterSoft.SonarQubeConnector
{
    public interface ISession
    {
        void Connect(string v1, string v2, string v3);

        /// <summary>
        /// Create new instance of a query service
        /// </summary>
        TService CreateQueryService<TService>();

        /// <summary>
        /// Create service to retrieve data from SonarQube
        /// </summary>
        T CreateCommand<T>() where T : ICommand;

        /// <summary>
        /// Execute the command, exception thrown if it fails
        /// </summary>
        void SubmitCommand<T>(T command) where T : ICommand;

    }
}