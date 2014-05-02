using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKata
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (input == "") return 0;
            var numbers = GetNumbers(input);
            CheckForNegatives(numbers);
            numbers = FilterNumbersGreaterThan1000(numbers);
            return numbers.Sum();
        }

        private static IEnumerable<int> FilterNumbersGreaterThan1000(IEnumerable<int> numbers)
        {
            numbers = numbers.Where(i => i <= 1000);
            return numbers;
        }

        private static void CheckForNegatives(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(i => i < 0);
            if (negatives.Any())
            {
                throw new ApplicationException(string.Format("negatives not allowed {0}", string.Join(",", negatives)));
            }
        }

        private IEnumerable<int> GetNumbers(string input)
        {
            var delimiters = GetDelimiters(input);
            input = RemoveCustomDelimiterSection(input);
            var numbers = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            return numbers;
        }

        private static string RemoveCustomDelimiterSection(string input)
        {
            if (HasCustomDelimiterSection(input))
            {
                input = input.Substring(GetFirstIndexOfNewLine(input) + 1);
            }
            return input;
        }

        public string[] GetDelimiters(string input)
        {
            var delimiters = new List<string> {",", "\n"};
            if (HasCustomDelimiterSection(input))
            {
                var customDelimiters = GetCustomDelimiters(input);
                delimiters.AddRange(customDelimiters);
            }
            return delimiters.ToArray();
        }

        private static string[] GetCustomDelimiters(string input)
        {
            var customDelimiterSection = input.Substring(0, GetFirstIndexOfNewLine(input));
            var customDelimiters = customDelimiterSection.Replace("//", "")
                                                         .Trim('[', ']')
                                                         .Split(new string[] {"]["}, StringSplitOptions.RemoveEmptyEntries);
            return customDelimiters;
        }

        private static bool HasCustomDelimiterSection(string input)
        {
            return input.StartsWith("//");
        }

        private static int GetFirstIndexOfNewLine(string input)
        {
            return input.IndexOf("\n");
        }
    }
}