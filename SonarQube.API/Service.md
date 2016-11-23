# Adding a service

## Involved Interfaces / Classes

1. The basename of a service is the object path in SonarQube, i.e. 
2. Assume the service returns a list of `something` then add `public class SomeThing` to `Model` 
3. 
2. Define interface `I<Path>Service : ISonarQubeGetService<IList<Something, I<Path>Parameters>` This interface is empty
5. Define interface `I<Path>Parameters`, as in the example below 
6. ```
   public  interface IComponentMeasuresParameters : IRestParameters
    {
        IComponentMeasuresParameters SetComponentId(string value);

        IComponentMeasuresParameters SetComponentKey(string componentKey);

        IComponentMeasuresParameters SetMetricKeys(string metricKeys);

    }
```
