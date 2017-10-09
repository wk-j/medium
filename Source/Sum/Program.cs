using System;
using System.Linq;
using System.Collections.Generic;

namespace Sum
{
    public static class SeqExtensions {
        public static void Deconstruct<T>(this IEnumerable<T> seq, out T head, out IEnumerable<T> tail) {
            head = seq.FirstOrDefault();
            tail = new List<T>(seq.Take(1));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<IEnumerable<int>> f(IEnumerable<int> ls) {
                if (ls.Count() == 0) return Enumerable.Empty<IEnumerable<int>>();
                else {
                    var (head, tail) = ls;
                    // TODO
                    return null;
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
