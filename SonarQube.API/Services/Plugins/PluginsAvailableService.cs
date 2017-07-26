
using PeterSoft.SonarQube.Connector.API.Logic;
using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Services
{
    internal class PluginsAvailableService: ServiceBase<PluginsAvailable>, IPluginsAvailableService
    {

        public PluginsAvailableService(RestClient restGetter, IRestParameters parameters): base(restGetter, parameters,"plugins/available") { }

    }
}
