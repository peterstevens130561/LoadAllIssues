using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQubeConnector.Models;
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Client;

namespace PeterSoft.SonarQubeConnector.Services
{
    class QualityProfilesSearchService : ServiceBase<ProfilesSearchResponse>, IQualityProfilesSearchService
    {
        public QualityProfilesSearchService (RestClient restGetter, IRestParameters parameters): base(restGetter, parameters, "qualityprofiles/search") { }

        public IQualityProfilesSearchService SetDefaults(bool selectDefaults)
        {
            SetParameter(@"defaults", selectDefaults);
            return this;
        }

        public IQualityProfilesSearchService SetLanguageKey(string languageKey)
        {
            SetParameter(@"language", languageKey);
            return this;
        }

        public IQualityProfilesSearchService SetProfileName(string profileName)
        {
            SetParameter(@"profilename", profileName);
            return this;
        }

        public IQualityProfilesSearchService SetProjectKey(string projectKey)
        {
            SetParameter(@"projeckey", projectKey);
            return this;
        }

        public new IList<Profile> Execute()
        {
            var response = base.Execute();
            return response.Profiles;
        }

    }

    class ProfilesSearchResponse
    {
         public IList<Profile> Profiles { get; set; }
    }
}
