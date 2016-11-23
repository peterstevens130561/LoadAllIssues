using SonarQube.API.Model;

namespace SonarQube.API.Services
{
    public interface IComponentMeasuresService : ISonarQubeGetService<ComponentMeasures, IComponentMeasuresParameters>
    {
    }
}