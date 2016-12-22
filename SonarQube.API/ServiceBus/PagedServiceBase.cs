
using System.Collections.Generic;
using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Services
{
    /// <summary>
    /// Gets all pages for the path specified in the constructor in list of which elements have
    /// type T. The response type is in V
    /// 
    /// The response must extend PageBase
    /// 
    /// PageBase must implement 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V">response type</typeparam>
    internal class PagedServiceBase<T,V> :  IPagedService<T,V> where V : Page<T>
    {
        private readonly ServiceBase<V> restGetService;
        public PagedServiceBase(RestClient restGetter, string path) 
        {
            restGetService = new ServiceBase<V>(restGetter, path);
        }

        public IList<T> Execute()
        {
            var items = new List<T>();
            V response = restGetService.Execute();
            items.AddRange(response.Items);
            int page = 0;
            while (response.Items.Count > 0)
            {
                page += 1;
                restGetService.SetParameter("p", page);
                response = restGetService.Execute();
                items.AddRange(response.Items);
            }
            return items;
        }

        internal void SetParameter(string key, string value)
        {
            restGetService.SetParameter(key, value);
        }
    }
}