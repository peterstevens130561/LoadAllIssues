using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Infrastructure.Commands;

namespace PeterSoft.SonarQube.Connector.Commands
{
    public interface IActivateRuleInQualityProfileCommand : ICommand
    {
        IActivateRuleInQualityProfileCommand SetProfileKey(string profileKey);
        IActivateRuleInQualityProfileCommand SetRuleKey(string ruleKey);
        IActivateRuleInQualityProfileCommand SetSeverity(string severity);
    }
}
