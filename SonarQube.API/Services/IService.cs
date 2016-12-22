using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IService< out T>
    {
        T Execute();
    }
}
