using PeterSoft.SonarQube.Connector.Client;

namespace PeterSoft.SonarQube.Connector.Infrastructure.Commands
{
    public interface ICommand
    {
        IRestParameters Parameters();
    }
}