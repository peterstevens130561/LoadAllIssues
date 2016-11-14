using LoadAllIssues.Model;
using System.Collections.Generic;
using System;

namespace LoadAllIssues.Services
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