
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands;
using System;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Commands.Factory
{
    class CommandFactory : AbstractCommandFactory
    {
        public CommandFactory(IRestClient restClient) : base(restClient)
        {

            Register<IIssuesAssignCommand, IssuesAssignCommand, IssuesAssignCommandHandler>();
            Register<IDevCockpitRunCommand, DevCockpitRunCommand, DevCockpitRunCommandHandler>();
            Register<IActivateRuleInQualityProfileCommand, QualityProfilesActivateRuleCommand, ActivateRuleInQualityProfileCommandHandler>();
            Register<IPermissionsApplyTemplateCommand, PermissionsApplyTemplateCommand, PermissionsApplyTemplateCommandHandler>();
            Register<IPermissionsBulkApplyTemplateCommand, PermissionsBulkApplyTemplateCommand, PermissionsBulkApplyTemplateCommandHandler>();
            Register<IPermissionsCreateTemplateCommand, PermissionsCreateTemplateCommand, PermissionsCreateTemplateCommandHandler>();
            Register<IQualityProfilesSetDefaultCommand, QualityProfilesSetDefaultCommand, QualityProfilesSetDefaultCommandHandler>();
        }
  
    }
}
