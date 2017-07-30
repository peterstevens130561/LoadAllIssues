namespace PeterSoft.SonarQube.Connector.Client
{
    /// <summary>
    /// Crude client, support Get and Post. 
    /// </summary>
    public interface IRestClient
    {
         IRestClient SetPath(string path);
        /// <summary>
        /// execute a get, path should be set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns>string</returns>
        string Get(IRestParameters parameters);

        /// <summary>
        /// set before calling Execute or Post
        /// </summary>
        /// <param name="credentials"></param>
        void SetCredentials(ICredentials credentials);

        /// <summary>
        /// execute a post, path should be set.
        /// </summary>
        /// <param name="parameters"></param>
        void Post(IRestParameters parameters);
        /// <summary>
        /// gets the result of the post. Not all Post actions will return something
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetPostResult<T>();
    }
}