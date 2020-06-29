using System;
using System.Collections.Generic;
using System.Text;

namespace RangeFilter
{
    public class RangeFilter<T> : IRangeFilter<T> where T:struct
    {
        public T? From { get; set; }
        public T? To { get; set; }
    }
}
