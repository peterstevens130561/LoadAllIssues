

namespace PeterSoft.SonarQube.Connector.Commands
{
    public interface IQualityProfilesSetDefaultCommand : ICommand
    {
        IQualityProfilesSetDefaultCommand SetProfileKey(string profileKey);
        IQualityProfilesSetDefaultCommand SetLanguage(string langugage);
        IQualityProfilesSetDefaultCommand SetProfileName(string profileName);
    }
}
