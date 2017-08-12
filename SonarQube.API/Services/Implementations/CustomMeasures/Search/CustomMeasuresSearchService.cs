
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;


namespace PeterSoft.SonarQube.Connector.Services
{
    internal class CustomMeasuresSearchService : PagedServiceBase<CustomMeasure, CustomMeasuresSearchPage>, ICustomMeasuresSearchService

    {

        public CustomMeasuresSearchService(IRestClient restGetter,IRestParameters parameters) : base(restGetter, parameters, "custom_measures/search") { }
  

        public ICustomMeasuresSearchService SetProjectKey(string projectKey)
        {
            SetParameter(@"projectKey", projectKey);
            return this;
        }

        public ICustomMeasuresSearchService SetProjectId(string projectId)
        {
            SetParameter(@"projectId", projectId);
            return this;
        }

    }

    public class CustomMeasuresSearchPage : Page<CustomMeasure>
    {

        public IList<CustomMeasure> CustomMeasures { get; set; }

        public override IList<CustomMeasure> Items
        {
            get
            {
                return CustomMeasures;
            }
        }
    }
}
