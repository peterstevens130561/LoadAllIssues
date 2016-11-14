using System;
using System.Text.RegularExpressions;
namespace Services.UnitTest
{
    public class EffortConversion
    {
        private EffortConversion()
        {

        }

        readonly static String pattern = "((?<day>\\d+)d)?((?<hour>\\d+)h)?((?<min>\\d+)min)?";
        public static int ConvertToMin(string effortTxt)
        {
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(effortTxt);
            int effort=0;
            foreach(Match match in matches)
            {
               effort += ToInt(match.Groups["day"])*480 + ToInt(match.Groups["hour"])*60 + ToInt(match.Groups["min"]);
            }
            return effort;
        }

        private static int ToInt(Group group)
        {
            int value = 0;
            if(group== null || !Int32.TryParse(group.Value,out value))
            {
                return 0;
            }
            return value;
        }
    }
}
