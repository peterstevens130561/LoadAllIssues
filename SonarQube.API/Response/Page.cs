using System.Collections.Generic;
using PeterSoft.SonarQubeConnector.Models;

namespace PeterSoft.SonarQubeConnector.Services
{
    /// <summary>
    /// Used for paged responses
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Page<T> : IPage<T> { 
    
        public int Total { get; set; }
        public int P { get; set; }
        public int Ps { get; set; }

        public Paging Paging { get; set; }
        public abstract IList<T> Items { get; }
    }
}