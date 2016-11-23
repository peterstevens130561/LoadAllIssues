namespace SonarQube.API.Logic
{
    public interface ISonarQubeService<out T>
    {
         T Execute();
    }
}