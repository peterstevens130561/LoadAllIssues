using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Services
{
    internal class ResourcesParameters : RestParameters, IResourcesParameters
    {

        public IResourcesParameters SetScope(string scope)
        {
            base.SetParameter(@"scope", scope);
            return this;
        }
    }
}