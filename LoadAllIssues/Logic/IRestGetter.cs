namespace LoadAllIssues.Logic
{
    public interface IRestGetter
    {
         IRestGetter SetPath(string path);
         T Execute<T>(IRestParameters parameters);
    }
}