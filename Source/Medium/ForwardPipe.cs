using System;
using System.Linq;

namespace Medium {
    public static class Extensions {
        public static TResult Forward<T, TResult>(this T value, Func<T, TResult> function) 
            => function(value);
        public static void Forward<T>(this T value, Action<T> function) 
            => function(value);
    }
}