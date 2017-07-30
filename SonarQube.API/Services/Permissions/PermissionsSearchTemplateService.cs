
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Models;

namespace PeterSoft.SonarQube.Connector.Services
{
    internal class PermissionsSearchTemplateService: ServiceBase<PermissionTemplates>, IPermissionsSearchTemplateService
    {
        public PermissionsSearchTemplateService(RestClient restGetter, IRestParameters parameters) : base(restGetter, parameters, @"permissions/search_templates")
        { }

        public IPermissionsSearchTemplateService SetFilter(string filter)
        {
            SetParameter(@"q", filter);
            return this;
        }
    }
}
