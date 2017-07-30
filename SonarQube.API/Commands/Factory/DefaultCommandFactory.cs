using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQube.Connector.Client;

namespace PeterSoft.SonarQube.Connector.Commands.Factory
{
    class DefaultCommandFactory : CommandFactory
    {
        public DefaultCommandFactory(IRestClient restClient) : base(restClient)
        {
            var commandFactory = this;
            commandFactory.Register<IIssuesAssignCommand, IssuesAssignCommand>();
            commandFactory.Register<IDevCockpitRunCommand, DevCockpitRunCommand>();
            commandFactory.Register<IActivateRuleInQualityProfileCommand, QualityProfilesActivateRuleCommand>();
            commandFactory.Register<IPermissionsApplyTemplateCommand, PermissionsApplyTemplateCommand>();
            commandFactory.Register<IPermissionsBulkApplyTemplateCommand, PermissionsBulkApplyTemplateCommand>();
            commandFactory.Register<IPermissionsCreateTemplateCommand, PermissionsCreateTemplateCommand>();
        }
    }
    }
