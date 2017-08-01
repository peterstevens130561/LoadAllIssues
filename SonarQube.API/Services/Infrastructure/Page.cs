using System.Collections.Generic;
using PeterSoft.SonarQube.Connector.Models;

namespace PeterSoft.SonarQube.Connector.Services
{
    /// <summary>
    /// Used for paged responses
    /// </summary>
    /// <typeparam name="T">Is the arrayList of items that we're interested in </typeparam>
    public abstract class Page<T> : IPage<T> { 
    
        public int Total { get; set; }
        public int P { get; set; }
        public int Ps { get; set; }

        public Paging Paging { get; set; }
        public abstract IList<T> Items { get; }
    }
}