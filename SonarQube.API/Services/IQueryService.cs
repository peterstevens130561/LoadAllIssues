
using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IQueryService<out T>
    {

        T Execute();

        IRestParameters Parameters { get; }
    }
}