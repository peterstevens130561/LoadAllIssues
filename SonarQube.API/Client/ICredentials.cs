namespace PeterSoft.SonarQube.Connector.Client
{
    public interface ICredentials
    {
        string Password { get; }
        string Url { get; }
        string Username { get; }
    }
}