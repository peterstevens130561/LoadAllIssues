using PeterSoft.SonarQubeConnector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Services
{
    /// <summary>
    /// see webapi/qualityprofiles/search for info on the parameters
    /// </summary>
    public interface IQualityProfilesSearchService : IExecuteService<IList<Profile>>
    {
        /// <summary>
        /// specify whether default profiles are returned.
        /// </summary>
        /// <param name="selectDefaults"></param>
        /// <returns></returns>
        IQualityProfilesSearchService SetDefaults(Boolean selectDefaults);
        IQualityProfilesSearchService SetLanguageKey(string languageKey);
        IQualityProfilesSearchService SetProfileName (string profileName);
        IQualityProfilesSearchService SetProjectKey(string projectKey);
    }
}
