using PeterSoft.SonarQube.Connector.Client;

namespace PeterSoft.SonarQube.Connector.Commands
{
    /// <summary>
    /// Each POST operation should implement ICommand, and a corresponding CommandHandler which implements ICommandHandler
    /// 
    /// </summary>
    public interface ICommand
    {
        IRestParameters Parameters();
    }
}