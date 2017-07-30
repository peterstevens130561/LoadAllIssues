using PeterSoft.SonarQube.Connector.Models;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IComponentMeasuresService : IExecuteService<ComponentMeasures>
    {
        IComponentMeasuresService SetComponentId(string value);

        IComponentMeasuresService SetComponentKey(string componentKey);

        IComponentMeasuresService SetMetricKeys(string metricKeys);

    }
}