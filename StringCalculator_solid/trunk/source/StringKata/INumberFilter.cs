using System.Collections.Generic;

namespace StringKata
{
    public interface INumberFilter
    {
        IEnumerable<int> Filter(IEnumerable<int> numbers);
    }
}