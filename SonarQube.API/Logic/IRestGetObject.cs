namespace SonarQube.API.Logic
{
    internal interface ISonarQubeService<T>
    {
        T Execute();
    }
}