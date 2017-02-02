
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IPagedService<T, V> : IExecuteService<IList<T>> where V : Page<T>
    {
    }
}