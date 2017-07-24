using PeterSoft.SonarQube.Connector.API.Logic;

namespace PeterSoft.SonarQube.Connector.Infrastructure.Commands
{
    public interface ICommand
    {
        IRestParameters Parameters();
    }
}