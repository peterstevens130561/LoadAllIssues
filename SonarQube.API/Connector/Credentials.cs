

namespace PeterSoft.SonarQubeConnector.API.Logic
{
    /// <summary>
    /// Simple value object for the user's credentials
    /// </summary>
    internal class Credentials : ICredentials
    {
        private readonly string password;
        private readonly string url;
        private readonly string username;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">of the server, and port</param>
        /// <param name="username">4-3-1 of the user</param>
        /// <param name="password">and the password</param>
        public Credentials(string url, string username, string password)
        {
            this.url = url;
            this.username = username;
            this.password = password;
        }

        public string Password
        {
            get
            {
                return password;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
        }
    }
}