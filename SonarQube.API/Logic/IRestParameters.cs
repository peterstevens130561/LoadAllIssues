namespace SonarQube.API.Logic
{
    public interface IRestParameters
    {
        string GetParameter(string v);
        IRestParameters SetParameter(string v, string value);
        string Build();
    }
}