﻿using PeterSoft.SonarQubeConnector.Models;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IComponentMeasuresService : IExecuteService<ComponentMeasures>
    {
        IComponentMeasuresService SetComponentId(string value);

        IComponentMeasuresService SetComponentKey(string componentKey);

        IComponentMeasuresService SetMetricKeys(string metricKeys);

    }
}