using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Infrastructure.Commands;

namespace PeterSoft.SonarQubeConnector.Commands
{
    public interface IActivateRuleInQualityProfileCommand : ICommand
    {
        IActivateRuleInQualityProfileCommand SetProfileKey(string profileKey);
        IActivateRuleInQualityProfileCommand SetRuleKey(string ruleKey);
        IActivateRuleInQualityProfileCommand SetSeverity(string severity);
    }
}
