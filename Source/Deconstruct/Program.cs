using System;

namespace Deconstruct {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;


    public static class Extensions {
        public static void Deconstruct<T>(this T[] array, out T head, out T[] tail) {
            head = array[0];
            tail = new ArraySegment<T>(array, 1, array.Length - 1).ToArray();
        }
    }

    class Program {
        static void Main(string[] args) {
            var (head, tail) = new[] { 1, 2, 3, 4, 5 };
        }
    }


}