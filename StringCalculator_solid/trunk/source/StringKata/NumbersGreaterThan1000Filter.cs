using System.Collections.Generic;
using System.Linq;

namespace StringKata
{
    public class NumbersGreaterThan1000Filter : INumberFilter
    {
        public IEnumerable<int> Filter(IEnumerable<int> numbers)
        {
            return numbers.Where(i => i <= 1000);
        }
    }
}