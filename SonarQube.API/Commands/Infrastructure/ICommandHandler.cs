namespace PeterSoft.SonarQube.Connector.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// executes a POST operation
        /// </summary>
        /// <param name="command"></param>
        void Execute(TCommand command);
    }
}