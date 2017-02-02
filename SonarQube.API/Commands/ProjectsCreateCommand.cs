using PeterSoft.SonarQubeConnector.Client;
using PeterSoft.SonarQubeConnector.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Commands
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
