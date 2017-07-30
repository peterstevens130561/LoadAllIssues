using PeterSoft.SonarQube.Connector.Client;
using System;

namespace PeterSoft.SonarQube.Connector.Commands
{
    class ProjectsCreateCommand : ParametersBase,IProjectsCreateCommand
    {
        public ProjectsCreateCommand(IRestParameters restParameters) : base(restParameters)
        {
        }

        IProjectsCreateCommand IProjectsCreateCommand.SetBranch(string branch)
        {
            throw new NotImplementedException();
        }

        IProjectsCreateCommand IProjectsCreateCommand.SetKey(string key)
        {
            throw new NotImplementedException();
        }

        IProjectsCreateCommand IProjectsCreateCommand.SetName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
