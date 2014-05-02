using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKata
{
    public interface IStringParser
    {
        IEnumerable<int> ParseNumbers(string input);
    }

    public class StringParser : IStringParser
    {

        public IEnumerable<int> ParseNumbers(string input)
        {
            var delimiters = ParseDelimiters(input);
            input = RemoveCustomDelimiterSection(input);
            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.None).Select(int.Parse);
            return numbers;
        }

        private static string RemoveCustomDelimiterSection(string input)
        {
            if (HasCustomDelimiterSection(input))
            {
                input = input.Substring(input.IndexOf("\n", StringComparison.CurrentCulture) + 1);
            }
            return input;
        }

        public IEnumerable<string> ParseDelimiters(string input)
        {
            var delimiters = new List<string> { ",", "\n" };
            if (HasCustomDelimiterSection(input))
            {
                RemoveDefaultDelimiters(delimiters);
                var customDelimiters = GetCustomDelimiters(input);
                delimiters.AddRange(customDelimiters);
            }

            return delimiters.ToArray();
        }

        private static void RemoveDefaultDelimiters(List<string> delimiters)
        {
            delimiters.Clear();
        }

        private static string[] GetCustomDelimiters(string input)
        {
            var customDelimiterSection = input.Substring(0, input.IndexOf("\n") + 1).Replace("//", "").Replace("\n", "");
            var customDelimiters = customDelimiterSection.Trim('[', ']').Split(new[] {"]["}, StringSplitOptions.None);
            return customDelimiters;
        }

        private static bool HasCustomDelimiterSection(string input)
        {
            return input.StartsWith("//");
        }
    }
}