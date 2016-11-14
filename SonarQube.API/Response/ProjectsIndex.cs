using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarQube.API.Response
{
    class ProjectsIndex
    {
        public IList<Project> Projects { get; set; }
    }
}
