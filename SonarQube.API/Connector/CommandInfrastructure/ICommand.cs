using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Infrastructure.Commands
{
    public interface ICommand
    {
        IRestParameters Parameters();
    }
}