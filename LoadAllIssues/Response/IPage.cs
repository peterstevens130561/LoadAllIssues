using LoadAllIssues.Model;
using System.Collections.Generic;

namespace LoadAllIssues.Services
{

    public interface IPage<T>
    {
        int Total { get; set; }
        int P { get; set; }
        int PS { get; set; }

        Paging Paging { get; set; }

        IList<T> Items { get; }
    }
}