using PeterSoft.SonarQube.Connector.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Commands
{
    public interface IProjectsCreateCommand : ICommand
    {
        /// <summary>
        /// set branch of the project (optional)
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        IProjectsCreateCommand SetBranch(string branch);
        /// <summary>
        /// set key of the project (required)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IProjectsCreateCommand SetKey(string key);
        /// <summary>
        /// set name of the project (required)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IProjectsCreateCommand SetName(string name);
    }
}
