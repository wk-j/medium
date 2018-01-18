using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Initializer {

    public static class ListExtensions {
        public static void Add<T>(this List<T> list, int size, T defaultValue) {
            list.AddRange(Enumerable.Repeat(defaultValue, size));
        }
    }

    class Program {
        static void Main(string[] args) {
            var list = new List<int> {
                { 10, 100 },
                { 10, 200 },
                { 10, 300 }
            };

            Console.WriteLine(list.Where(x => x == 100).Count() == 10);
            Console.WriteLine(list.Where(x => x == 200).Count() == 10);
            Console.WriteLine(list.Where(x => x == 300).Count() == 10);
        }
    }

}