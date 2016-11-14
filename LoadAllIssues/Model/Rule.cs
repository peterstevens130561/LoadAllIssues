using System.Collections.Generic;

namespace LoadAllIssues.Model
{


    public class Rule
    {
        public string Key { get; set; }
        public string Repo { get; set; }
        public string Name { get; set; }
        public string HtmlDesc { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
        public string InternalKey { get; set; }
        public bool Template { get; set; }
        public IList<string> Tags { get; set; }
        public IList<string> SysTags { get; set; }
        public string RemFnType { get; set; }
        public string RemFnGapMultiplier { get; set; }
        public string RemFnBaseEffort { get; set; }
        public string DefaultRemFnType { get; set; }
        public string DefaultRemFnGapMultiplier { get; set; }
        public string DefaultRemFnBaseEffort { get; set; }
        public bool RemFnOverloaded { get; set; }
        public string GapDescription { get; set; }
        public string Lang { get; set; }
        public string LangName { get; set; }
        public string Type { get; set; }
        public List<RuleParam> @Params { get; set; }
    }

    public class RuleParam
    {
        public string Key { get; set; }
        public string Desc { get; set; }
        public string DefaultValue { get; set; }
    }
    public class RuleProfileParam
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class Active
    {
        public string QProfile { get; set; }
        public string Inherit { get; set; }
        public string Severity { get; set; }
        public List<RuleProfileParam> @Params { get; set; }
    }
}