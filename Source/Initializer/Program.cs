using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Initializer {

    public static class ListExtensions {
        public static void Add<T>(this List<T> list, int size, T defaultValue) {
            list.AddRange(Enumerable.Repeat(defaultValue, size));
        }

        public static void Deconstruct<T>(this T[] array, out T head, out T[] tail) {
            head = array[0];
            tail = new ArraySegment<T>(array, 1, array.Length - 1).ToArray();
        }
    }

    class Program {
        static void Main(string[] args) {

            var list = new List<int> {
                { 10, 100 },
                { 10, 200 },
                { 10, 300 },
                1,2,3,4
            };

            var array = new[] {
                1,2,3,4,4,6
            };

            var dict = new Dictionary<string, int> {
                { "A", 100 },
                { "B", 200 }
            };


            Console.WriteLine(list.Where(x => x == 100).Count() == 10);
            Console.WriteLine(list.Where(x => x == 200).Count() == 10);
            Console.WriteLine(list.Where(x => x == 300).Count() == 10);

            var (head, tail) = new[] { 1, 2, 3, 4 };
        }
    }

}