using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQube.Connector.API.Logic;

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
