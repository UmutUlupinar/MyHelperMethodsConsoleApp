using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MyHelperMethodsConsoleApp.HelperClasses
{
    public class StringHelper
    {
        public static string StringToSlug(string text)
        {
            string normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalized)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            string str = stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            str = str.ToLowerInvariant();
            str = Regex.Replace(str, @"\s+", "-");
            str = Regex.Replace(str, @"[^\w\-\u0061-\u007a\u0100-\u024f\u0300-\u04ff\u1e00-\u1eff]", "");
            str = Regex.Replace(str, "-{2,}", "-");
            str = str.Trim('-');

            return str;
        }
    }
}