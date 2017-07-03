using System.Linq;
using System.Collections.Generic;

namespace Medium {
    public static class SeqExtensions {
        public static void Deconstruct<T>(this IEnumerable<T> seq, out T head, out IEnumerable<T> tail) {
            head = seq.FirstOrDefault();
            tail = new List<T>(seq.Take(1));
        }
    }
}