
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Models;

namespace PeterSoft.SonarQube.Connector.Services
{
    internal class PluginsAvailableService: ServiceBase<PluginsAvailable>, IPluginsAvailableService
    {

        public PluginsAvailableService(IRestClient restGetter, IRestParameters parameters): base(restGetter, parameters,"plugins/available") { }

    }
}
