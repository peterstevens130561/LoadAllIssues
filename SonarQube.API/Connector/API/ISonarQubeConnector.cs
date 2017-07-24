
namespace PeterSoft.SonarQube.Connector
{
    public interface ISonarQubeConnector
    {
        ISession CreateSession();
    }
}