using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestDrivenDevelopment1
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            var splitedLines = numbers.Split('\n');

            var delimiterChars = GetDelimiters(splitedLines.First()).ToArray();

            var y = splitedLines.ToList();
            if(splitedLines.First()[..2].Equals("//")) y.RemoveAt(0);

            var stringNumbers = y.SelectMany(lines => lines.Split(delimiterChars, StringSplitOptions.None)).ToList();

            var parsedNumbers = stringNumbers.Select(x => int.Parse(x));

            var negatives = parsedNumbers.Where(x => x < 0).ToList();

            if (negatives.Any()) throw new Exception($"negatives not allowed {string.Join(",", negatives)}");

            return parsedNumbers.Where(x => x < 1000).Sum();
        }

        private static IEnumerable<string> GetDelimiters(string firstLine)
        {
            if (!firstLine[..2].Equals("//")) yield return ",";
            else
            {
                Regex rx = new Regex(@"\[[^\]]+\]");

                var matches = rx.Matches(firstLine);

                if (!matches.Any()) yield return firstLine.Substring(2, 1);

                foreach (var match in matches)
                {
                    yield return match.ToString().Replace("[", "").Replace("]", "");
                }
            }
        }
    }
}
