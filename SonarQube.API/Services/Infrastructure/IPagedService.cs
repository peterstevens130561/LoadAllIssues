﻿
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IPagedService<T, V> : IExecuteService<IList<T>> where V : Page<T>
    {
    }
}