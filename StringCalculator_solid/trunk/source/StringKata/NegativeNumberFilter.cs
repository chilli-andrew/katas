using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKata
{
    public class NegativeNumberFilter : INumberFilter
    {
        public IEnumerable<int> Filter(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(i => i < 0).ToList();
            if (negatives.Any())
            {
                throw new ApplicationException(string.Format("Negatives not allowed: {0}", string.Join("," , negatives)));
            }
            return numbers.ToList();
        }
    }
}