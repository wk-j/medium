using System.Linq;
using System.Collections.Generic;

public class P11 {
    public static IEnumerable<C<T>> EncodeModified<T>(IEnumerable<T> seq) {
        var empty = Enumerable.Empty<C<T>>().ToList();
        var ans = seq.Aggregate(empty, (a, x) => {
            var last = a.LastOrDefault();
            var lastIndex = a.LastIndexOf(last);
            switch (last) {
                case Single<T> s when (s.E.Equals(x)) : 
                    a[lastIndex] = new Multiple<T>(x, 2);
                    break;
                case Multiple<T> m when (last.E.Equals(x)) :
                    m.N ++;
                    break;
                default: 
                    a.Add(new Single<T>(x));
                    break;
            }
            return a;
        });
        return ans;
    }
}
