
using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    /// <summary>
    /// For paged response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPage<T>
    {
        /// <summary>
        /// total number of items
        /// </summary>
        int Total { get; set; }
        /// <summary>
        /// Page #
        /// </summary>
        int P { get; set; }
        /// <summary>
        /// Number of items in pages
        /// </summary>
        int Ps{ get; set; }

        /// <summary>
        /// Kind of duplicate
        /// </summary>
        Paging Paging { get; set; }

        /// <summary>
        /// The items in the response
        /// </summary>
        IList<T> Items { get; }
    }
}