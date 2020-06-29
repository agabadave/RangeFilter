using System;
using System.Collections.Generic;
using System.Text;

namespace RangeFilter
{
    public interface IRangeFilter<T> where T:struct
    {
        T? From { get; set; }
        
        T? To { get; set; }
    }
}
