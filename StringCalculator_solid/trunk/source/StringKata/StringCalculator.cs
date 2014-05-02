using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKata
{
    public class StringCalculator
    {
        private readonly IStringParser _stringParser;
        private readonly IList<INumberFilter> _numberFilters;

        public StringCalculator(IStringParser stringParser, IList<INumberFilter> numberFilters)
        {
            if (stringParser == null) throw new ArgumentNullException("stringParser");
            _stringParser = stringParser;
            _numberFilters = numberFilters;
        }

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;
            var numbers = _stringParser.ParseNumbers(input).ToList();
            foreach (var numberFilter in _numberFilters)
            {
                numbers = numberFilter.Filter(numbers).ToList();
            }
            return numbers.Sum();
        }
    }
}