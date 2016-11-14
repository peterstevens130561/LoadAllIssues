using System.Collections.Generic;
using LoadAllIssues.Services;

namespace LoadAllIssues.Model
{
    public abstract class PageBase<T> : IPage<T>
    {
        public int Total { get; set; }
        public int P { get; set; }
        public int PS { get; set; }

        public Paging Paging { get; set; }
        public abstract IList<T> Items { get; }
    }
}