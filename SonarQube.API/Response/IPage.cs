
using SonarQube.API.Model;
using System.Collections.Generic;

namespace SonarQube.API.Response
{

    public interface IPage<T>
    {
        int Total { get; set; }
        int P { get; set; }
        int Ps{ get; set; }

        Paging Paging { get; set; }

        IList<T> Items { get; }
    }
}