using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Iteration03
{
    public static class EnumerableExtensions
    {
        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (T item in items)
                action(item);
        }
    }
}