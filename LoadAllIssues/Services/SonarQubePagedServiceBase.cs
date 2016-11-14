﻿using LoadAllIssues.Logic;
using LoadAllIssues.Model;
using System.Collections.Generic;
using System;

namespace LoadAllIssues.Services
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
    public class SonarQubePagedServiceBase<T,V> where V: PageBase<T>
    {
        private readonly SonarQubeServiceBase<V> restGetService;
        public SonarQubePagedServiceBase(RestGetter restGetter, string path) 
        {
            restGetService = new SonarQubeServiceBase<V>(restGetter, path);
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