namespace PeterSoft.SonarQubeConnector.API.Logic
{
    internal interface IRestClient
    {
         IRestClient SetPath(string path);
         T Execute<T>(IRestParameters parameters);

        void Connect(ICredentials credentials);

        void Post(IRestParameters parameters);
        T GetPostResult<T>();
    }
}