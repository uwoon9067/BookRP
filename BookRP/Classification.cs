using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRP
{
    internal class Classification
    {
        public static List<string> List { get; set; } = new()
        {
            "총류",
            "철학",
            "종교",
            "사회과학",
            "자연과학",
            "기술과학",
            "예술",
            "언어",
            "문학",
            "역사"
        };

        public static Dictionary<string, string> Dictionary { get; set; } = new()
        {
            { "총류", "000" },
            { "철학", "100" },
            { "종교", "200" },
            { "사회과학", "300" },
            { "자연과학", "400" },
            { "기술과학", "500" },
            { "예술", "600" },
            { "언어", "700" },
            { "문학", "800" },
            { "역사", "900" },
        };
    }
}
