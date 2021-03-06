﻿using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Commands
{
    public class QualityProfilesActivateRuleCommand : ParametersBase, IActivateRuleInQualityProfileCommand
    {
        public QualityProfilesActivateRuleCommand(IRestParameters restParameters) : base(restParameters)
        {
        }

        public IActivateRuleInQualityProfileCommand SetRuleKey(string ruleKey)
        {
            SetParameter(@"rule_key", ruleKey);
            return this;
        }

        public IActivateRuleInQualityProfileCommand SetProfileKey(string profileKey)
        {
            SetParameter(@"profile_key",profileKey);
            return this;
        }

        public IActivateRuleInQualityProfileCommand SetSeverity(string severity)
        {
            SetParameter(@"severity", severity);
            return this;
        }

    }
}
