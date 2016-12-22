namespace PeterSoft.SonarQubeConnector.Services
{
    public interface ISonarQubeService<out T>
    {
         T Execute();
    }
}