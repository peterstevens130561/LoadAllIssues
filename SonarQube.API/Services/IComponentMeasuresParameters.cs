using SonarQube.API.Logic;

namespace SonarQube.API.Services
{
    public  interface IComponentMeasuresParameters : IRestParameters
    {
        IComponentMeasuresParameters SetComponentId(string value);

        IComponentMeasuresParameters SetComponentKey(string componentKey);

        IComponentMeasuresParameters SetMetricKeys(string metricKeys);

    }
}