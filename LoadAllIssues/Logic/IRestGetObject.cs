namespace LoadAllIssues.Logic
{
    internal interface ISonarQubeService<T>
    {
        T Execute();
    }
}