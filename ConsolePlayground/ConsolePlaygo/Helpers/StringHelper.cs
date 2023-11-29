using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Helpers
{
    public static class StringHelper
    {
        public static string ToTitleCase(this string x)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCaseString = textInfo.ToTitleCase(x);

            return titleCaseString;
        }
    }
}
