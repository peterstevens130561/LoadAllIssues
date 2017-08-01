
using System.Collections.Generic;
using PeterSoft.SonarQube.Connector.Client;
using System;

namespace PeterSoft.SonarQube.Connector.Services
{
    /// <summary>
    /// Gets all pages for the path specified in the constructor in list of which elements have
    /// type T. The response type is in V
    /// 
    /// The response must extend PageBase
    /// 
    /// PageBase must implement 
    /// </summary>
    /// <typeparam name="ListItem">the type which we want in the list</typeparam>
    /// <typeparam name="ResponsePage">response type, which holds a page</typeparam>
    internal class PagedServiceBase<ListItem,ResponsePage> :  IPagedService<ListItem,ResponsePage> where ResponsePage : Page<ListItem>
    {
        private readonly ServiceBase<ResponsePage> restService;
        public PagedServiceBase(IRestClient restGetter, IRestParameters restParameters,string path) : this(new ServiceBase<ResponsePage>(restGetter, restParameters, path)) { }


        public PagedServiceBase(ServiceBase<ResponsePage> serviceBase)
        {
            this.restService = serviceBase;
        }
        public IList<ListItem> Execute()
        {
            var items = new List<ListItem>();
            ResponsePage response = GetItems(items);
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
        private ResponsePage GetItems(List<ListItem> items)
        {
            ResponsePage response = restService.Execute();
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

        internal void SetIsoDateParameter(string parameter, DateTimeOffset date)
        {
            string value = date.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            restService.SetParameter(parameter, value);
        }
    }
}