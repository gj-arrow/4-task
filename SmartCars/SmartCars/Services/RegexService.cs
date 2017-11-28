using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SmartCars.Services
{
    public class RegexService
    {
        public static List<int> GetMatchListInt(string patternStr, string text)
        {
            var resultList = new List<int>();
            foreach (Match match in Regex.Matches(text, patternStr, RegexOptions.IgnoreCase))
            {
                resultList.Add(Int32.Parse(match.Value));
            }
            return resultList;
        }

        public static string GetMatchString(string patternStr, string text)
        {
            var resultList = "";
            foreach (Match match in Regex.Matches(text, patternStr, RegexOptions.IgnoreCase))
            {
                resultList+=match.Groups[1].Value + ',';
            }
            return resultList;
        }

        public static int GetMatchMaxInt(string patternStr, string textElement)
        {
            var resultList = GetMatchListInt(patternStr, textElement);
            resultList.Sort();
            return resultList.Last();
        }
    }
}
