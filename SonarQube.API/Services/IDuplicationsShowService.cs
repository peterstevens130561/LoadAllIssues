using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IDuplicationsShowService : IService
    {
        IDuplicationsShowService SetFileKey(string fileKey);
        IDuplicationsShowService SetUUID(string uuid);
    }
}
