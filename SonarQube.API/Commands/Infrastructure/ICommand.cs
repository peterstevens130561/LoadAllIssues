using PeterSoft.SonarQube.Connector.Client;

namespace PeterSoft.SonarQube.Connector.Commands
{
    public interface ICommand
    {
        IRestParameters Parameters();
    }
}