

namespace PeterSoft.SonarQube.Connector.Commands
{
    public interface IActivateRuleInQualityProfileCommand : ICommand
    {
        IActivateRuleInQualityProfileCommand SetProfileKey(string profileKey);
        IActivateRuleInQualityProfileCommand SetRuleKey(string ruleKey);
        IActivateRuleInQualityProfileCommand SetSeverity(string severity);
    }
}
