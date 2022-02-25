using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringKata
{
    public class StringCalculator
    {
        private const char DefaultDelimiter = ',';

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            IEnumerable<string> tokens = Tokenize(input);
            IEnumerable<int> numbers = tokens.Select(ConvertToNumber).ToList();

            CheckForNegativeNumbers(numbers);

            return numbers.Sum();
        }

        private static void CheckForNegativeNumbers(IEnumerable<int> numbers)
        {
            List<int> negativeNumbers = numbers.Where(number => number < 0).ToList();

            if (negativeNumbers.Count > 0)
                throw new ArgumentException("Negatives not allowed: " + FormatNegativeNumbers(negativeNumbers));
        }

        private static string FormatNegativeNumbers(IEnumerable<int> negativeNumbers)
        {
            return string.Join(" ", negativeNumbers);
        }

        private static IEnumerable<string> Tokenize(string input)
        {
            char delimiter = DefaultDelimiter;

            if (CustomDelimiterSpecified(input))
            {
                delimiter = ParseCustomDelimiter(ref input);
            }
            else
            {
                input = ReplaceAlternativeDelimitersWithCommas(input);
            }

            return input.Split(delimiter);
        }

        private static char ParseCustomDelimiter(ref string input)
        {
            char customDelimiter = input[2];
            input = input.Substring(4);
            return customDelimiter;
        }

        private static bool CustomDelimiterSpecified(string input)
        {
            return input.StartsWith("//");
        }

        private static string ReplaceAlternativeDelimitersWithCommas(string input)
        {
            return input.Replace("\n", ",");
        }

        private static int ConvertToNumber(string input)
        {
            return int.Parse(input);
        }
    }
}
