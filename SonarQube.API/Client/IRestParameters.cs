namespace PeterSoft.SonarQubeConnector.API.Logic
{
    public interface IRestParameters
    {
        string GetParameter(string v);
        IRestParameters SetParameter(string v, string value);

        IRestParameters SetParameter(string v, bool value);
        string Build();
    }
}