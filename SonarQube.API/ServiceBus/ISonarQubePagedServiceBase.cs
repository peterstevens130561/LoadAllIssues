using PeterSoft.SonarQubeConnector.API.Response;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface ISonarQubePagedServiceBase<T, V> where V : PageBase<T>
    {
        IList<T> Execute();
    }
}