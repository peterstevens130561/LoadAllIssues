
using PeterSoft.SonarQube.Connector.Models;
using System;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Models
{
    public class RulesShow
    {
        public Rule Rule { get; set; }
       public  IList<Active> Actives { get; set; }


    }
}