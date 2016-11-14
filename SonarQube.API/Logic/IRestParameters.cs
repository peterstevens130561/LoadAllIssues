namespace SonarQube.API.Logic
{
    public interface IRestParameters
    {
        string Get(string v);
        IRestParameters Add(string v, string value);
        string Build();
    }
}