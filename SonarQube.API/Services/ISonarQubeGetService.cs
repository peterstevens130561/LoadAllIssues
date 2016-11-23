using SonarQube.API.Logic;

namespace SonarQube.API.Services
{
    public interface ISonarQubeGetService<out T,out V> where V: IRestParameters
    {

        T Execute();

        V Parameters { get; }
    }
}