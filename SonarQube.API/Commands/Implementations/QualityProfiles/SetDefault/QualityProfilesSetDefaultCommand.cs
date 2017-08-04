using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Commands
{
    public class QualityProfilesSetDefaultCommand : ParametersBase, IQualityProfilesSetDefaultCommand
    {
        public QualityProfilesSetDefaultCommand(IRestParameters restParameters) : base(restParameters)
        {
        }

        public IQualityProfilesSetDefaultCommand SetLanguage(string language)
        {
            SetParameter(@"language", language);
            return this;
        }

        public IQualityProfilesSetDefaultCommand SetProfileKey(string profileKey)
        {
            SetParameter(@"profileKey",profileKey);
            return this;
        }

        public IQualityProfilesSetDefaultCommand SetProfileName(string profileName)
        {
            SetParameter(@"profileName", profileName);
            return this;
        }

    }
}
