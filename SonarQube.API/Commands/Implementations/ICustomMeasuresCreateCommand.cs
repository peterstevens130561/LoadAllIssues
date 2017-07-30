

namespace PeterSoft.SonarQube.Connector.Commands
{
    public interface ICustomMeasuresCreateCommand : ICommand
    {
       ICustomMeasuresCreateCommand SetmetricId(string metricId);
        ICustomMeasuresCreateCommand SetMetricKey(string metricKey);
        ICustomMeasuresCreateCommand SetProjectId(string projectId);
        ICustomMeasuresCreateCommand SetProjectKey(string projectKey);
        ICustomMeasuresCreateCommand SetValue(string value);
    }
}
