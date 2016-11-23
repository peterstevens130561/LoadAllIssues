using SonarQube.API.Logic;

namespace SonarQube.API.Services
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