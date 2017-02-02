
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
        private readonly ServiceBase<V> restService;
        public PagedServiceBase(IRestClient restGetter, IRestParameters restParameters,string path) : this(new ServiceBase<V>(restGetter, restParameters, path)) { }


        public PagedServiceBase(ServiceBase<V> serviceBase)
        {
            this.restService = serviceBase;
        }
        public IList<T> Execute()
        {
            var items = new List<T>();
            V response = GetItems(items);
            int page = 0;
            while (response.Items !=null && response.Items.Count > 0)
            {
                page += 1;
                restService.SetParameter(@"p", page);
                response = GetItems(items);
            }
            return items;
        }

        /// <summary>
        /// Gets a set of items
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private V GetItems(List<T> items)
        {
            V response = restService.Execute();
            if (response.Items != null)
            {
                items.AddRange(response.Items);
            }

            return response;
        }

        internal void SetParameter(string key, string value)
        {
            restService.SetParameter(key, value);
        }
    }
}