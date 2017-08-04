using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQube.Connector.Client;

namespace PeterSoft.SonarQube.Connector.Services.Factory
{
    class DefaultServiceFactory : AbstractServiceFactory
    {
        public DefaultServiceFactory(RestClient restGetter) : base(restGetter)
        {
            base.Register<IComponentMeasuresService, ComponentMeasuresService>()
            .Register<IProjectsIndexService, ProjectsIndexService>()
            .Register<IRulesShowService, RulesShowService>()
            .Register<IRulesSearchService, RulesSearchService>()
            .Register<IResourcesService, ResourcesService>()
            .Register<IIssuesSearchService, IssuesSearchService>()
            .Register<IQualityProfilesSearchService, QualityProfilesSearchService>()
            .Register<IIssuesAuthorsService, IssuesAuthorsService>()
            .Register<IIssuesTagsService, IssuesTagsService>()
            .Register<IIssuesTransitionsService, IssuesTransitionsService>()
            .Register<IIssuesChangelogService, IssuesChangelogService>()
            .Register<IPermissionsSearchTemplateService, PermissionsSearchTemplateService>()
            .Register<IPluginsAvailableService, PluginsAvailableService>()
            .Register<ISourcesScmService, SourcesScmService>()
            .Register<IMeasuresComponentTreeService,MeasuresComponentTreeService>()
            .Register<IDuplicationsShowService,DuplicationsShowService>()
            ;
        }
    }
    }
