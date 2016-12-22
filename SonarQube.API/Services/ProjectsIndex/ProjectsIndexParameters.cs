using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Services
{
    internal class ProjectsIndexParameters : RestParameters, IProjectsIndexParameters
    {
        public IProjectsIndexParameters SetKey(string projectKey)
        {
            SetParameter("projectKey", projectKey);
            return this;
        }
    }
}
