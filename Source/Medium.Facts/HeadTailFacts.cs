using System.Collections.Generic;
using Xunit;
using System.Linq;
using System;

 public static class SeqExtensions {
    public static void Deconstruct<T>(this IEnumerable<T> seq, out T head, out IEnumerable<T> tail) {
        head = seq.FirstOrDefault();
        tail = new List<T>(seq.Take(1));
    }
}

public class HeadTailFacts {
    [Fact]
    public void T() {


        var list = new List<string> { "a", "a", "a", "b", "c", "c", "a", "a", "d", "e", "e", "e", "e" };
        var compress = list.Aggregate(Enumerable.Empty<string>(), (a, x) =>  
            a.LastOrDefault() == x ? a : a.Concat(new [] { x }));
        Assert.Equal(new List<string> { "a", "b", "c", "a", "d", "e" }, compress);


        var result2 = list.Aggregate(Enumerable.Empty<string>(), (a, x) =>  
            a.LastOrDefault() == x ? a : a.Concat(new List<string> { x }));
        Assert.Equal(new List<string> {"a", "b", "c", "a", "d", "e" }, result2);
    }
}