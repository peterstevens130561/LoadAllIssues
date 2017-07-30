using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQube.Connector.Client;

namespace PeterSoft.SonarQube.Connector.Commands.Bus
{
    class DefaultCommandBus : CommandBus
    {
        public DefaultCommandBus(RestClient restGetter) : base(restGetter)
        {
            RegisterCommandHandlers(this);
        }

        private void RegisterCommandHandlers(ICommandBus commandBus)
        {
            commandBus.Register<IssuesAssignCommand, IssuesAssignCommandHandler>();
            commandBus.Register<IActivateRuleInQualityProfileCommand, ActivateRuleInQualityProfileCommandHandler>();
            commandBus.Register<IDevCockpitRunCommand, DevCockpitRunCommandHandler>();
            commandBus.Register<IPermissionsApplyTemplateCommand, PermissionsApplyTemplateCommandHandler>();
            commandBus.Register<IPermissionsBulkApplyTemplateCommand, PermissionsBulkApplyTemplateCommandHandler>();
            commandBus.Register<IPermissionsCreateTemplateCommand, PermissionsCreateTemplateCommandHandler>();
        }
    }
}
