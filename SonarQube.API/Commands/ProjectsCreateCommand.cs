using PeterSoft.SonarQubeConnector.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Commands
{
    class ProjectsCreateCommand : IProjectsCreateCommand
    {
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
