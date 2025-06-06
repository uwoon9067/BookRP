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
    }
}
