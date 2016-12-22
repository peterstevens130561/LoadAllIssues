
using System.Collections.Generic;
using System;
using PeterSoft.SonarQubeConnector.Models;

namespace PeterSoft.SonarQubeConnector.API.Response
{
    public class RulesSearchPageC  : PageBase<Rule >
    {
        public override IList<Rule> Items
        {
            get
            {
                return Rules;
            }
        }

        public IList<Rule> Rules { get; set; }
    }
}