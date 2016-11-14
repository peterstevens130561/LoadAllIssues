using LoadAllIssues.Model;
using System;
using System.Collections.Generic;

namespace SonarQube.API.Response
{
    public class RulesShow
    {
        public Rule Rule { get; set; }
       public  IList<Active> Actives { get; set; }


    }
}