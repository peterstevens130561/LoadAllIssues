
using PeterSoft.SonarQubeConnector.Models;
using System;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.API.Response
{
    public class RulesShow
    {
        public Rule Rule { get; set; }
       public  IList<Active> Actives { get; set; }


    }
}