using PeterSoft.SonarQube.Connector.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
