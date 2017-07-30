
using PeterSoft.SonarQube.Connector.Services;

using PeterSoft.SonarQube.Connector.Client;
using System.Net;
using PeterSoft.SonarQube.Connector.Infrastructure.Commands;

using PeterSoft.SonarQube.Connector.Commands;
using PeterSoft.SonarQube.Connector.Infrastructure.Services;

namespace PeterSoft.SonarQube.Connector
{
    /// <summary>
    /// The connector is the one and only dependency that clients need to use.
    /// 
    /// Inject it via the constructor, then setup a session via CreateSession(url,username,password)
    /// 
    /// </summary>
    public class SonarQubeConnector : ISonarQubeConnector
    {
        private readonly ICommandBus commandBus;
        private readonly ICommandFactory commandFactory;
        private readonly RestClient restClient;
        private readonly IServiceFactory serviceFactory;
       

        public SonarQubeConnector() : this(new RestClient())
        {
        }

        internal SonarQubeConnector(RestClient restClient)
        {
            this.restClient = restClient;
            serviceFactory = new ServiceFactory(restClient);
            RegisterServices();
            commandFactory = new CommandFactory(restClient);
            RegisterCommands();
            commandBus = new CommandBus(restClient);
            RegisterCommandHandlers();
        }

        private void RegisterCommandHandlers()
        {
            commandBus.Register<IssuesAssignCommand, IssuesAssignCommandHandler>();
            commandBus.Register<IActivateRuleInQualityProfileCommand, ActivateRuleInQualityProfileCommandHandler>();
            commandBus.Register<IDevCockpitRunCommand, DevCockpitRunCommandHandler>();
            commandBus.Register<IPermissionsApplyTemplateCommand, PermissionsApplyTemplateCommandHandler>();
            commandBus.Register<IPermissionsBulkApplyTemplateCommand, PermissionsBulkApplyTemplateCommandHandler>();
            commandBus.Register<IPermissionsCreateTemplateCommand, PermissionsCreateTemplateCommandHandler>();
        }

        private void RegisterCommands()
        {
            commandFactory.Register<IIssuesAssignCommand, IssuesAssignCommand>();
            commandFactory.Register<IDevCockpitRunCommand, DevCockpitRunCommand>();
            commandFactory.Register<IActivateRuleInQualityProfileCommand, QualityProfilesActivateRuleCommand>();
            commandFactory.Register<IPermissionsApplyTemplateCommand, PermissionsApplyTemplateCommand>();
            commandFactory.Register<IPermissionsBulkApplyTemplateCommand, PermissionsBulkApplyTemplateCommand>();
            commandFactory.Register<IPermissionsCreateTemplateCommand, PermissionsCreateTemplateCommand>();
        }

        public ISession CreateSession()
        {
            return new Session(serviceFactory,commandFactory,commandBus);
        }

        private void RegisterServices()
        {
            serviceFactory.Register<IComponentMeasuresService, ComponentMeasuresService>()
            .Register<IProjectsIndexService, ProjectsIndexService>()
            .Register<IRulesShowService, RulesShowService>()
            .Register<IRulesSearchService,RulesSearchService>()
            .Register<IResourcesService, ResourcesService>()
            .Register<IIssuesSearchService, IssuesSearchService>()
            .Register<IQualityProfilesSearchService,QualityProfilesSearchService>()
            .Register<IIssuesAuthorsService,IssuesAuthorsService>()
            .Register<IIssuesTagsService,IssuesTagsService>()
            .Register<IIssuesTransitionsService,IssuesTransitionsService>()
            .Register<IIssuesChangelogService, IssuesChangelogService>()
            .Register<IPermissionsSearchTemplateService, PermissionsSearchTemplateService>()
            .Register<IPluginsAvailableService,PluginsAvailableService>()
            .Register<ISourcesScmService,SourcesScmService>()
            ;
        }

    }
}
