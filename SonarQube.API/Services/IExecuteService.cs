using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Services
{
    /// <summary>
    /// Each service will implement ultimately this one.
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IExecuteService< out T> : IService
    {
        T Execute();
    }
}
