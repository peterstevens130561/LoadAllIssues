using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Models
{
    public class TextRange
    {
        int StartLine { get; set; }
        int EndLine { get; set; }
        int StartOffset { get; set; }
        int EndOffset { get; set; }
    }
}
