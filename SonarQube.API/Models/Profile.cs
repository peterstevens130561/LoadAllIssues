using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Models
{
    public class Profile
    {
        /// <summary>
        /// Key of profile (created)
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Name of profile (given)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Programming language, internal key i.e. cs
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// Name of programming language, i.e. C#
        /// </summary>
        public string LanguageName { get; set; }
        /// <summary>
        /// true if the profile is inherited from another profile, see parentKey, parentName
        /// </summary>
        public bool IsInherited { get; set; }
        /// <summary>
        /// key of parent profile, valid with isInherited
        /// </summary>
        public string ParentKey { get; set; }
        /// <summary>
        /// name of parent profiel, valid with isInherited
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// number of active rules in this profile
        /// </summary>
        public int ActiveRuleCount { get; set; }
        /// <summary>
        /// true if this is the default profile
        /// </summary>
        public bool IsDefault { get; set; }
  
    }
}
