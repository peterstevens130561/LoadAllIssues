

namespace PeterSoft.SonarQubeConnector.API.Logic
{
    internal class Credentials : ICredentials
    {
        private readonly string password;
        private readonly string url;
        private readonly string username;

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