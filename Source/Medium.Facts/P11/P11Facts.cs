using Xunit;
using System.Collections.Generic;
using System.Linq;
using System;

public class C11Facts {
    
    string ToText<T>(IEnumerable<C<T>> seq) => seq.Select(x => $"({x})").Pipe(x => string.Join(" ", x));

    [Fact]
    public void TestChar() {
        var chars = "aaaabccaadeeee".ToCharArray();
        var text = P11.EncodeModified(chars).Pipe(ToText);
        Assert.Equal(text, "(Multiple 4 a) (Single b) (Multiple 2 c) (Multiple 2 a) (Single d) (Multiple 4 e)");
    }
    [Fact]
    public void TestInt() {
        var ints  = new List<int> { 0,0,0,0,1,2,2,3,5,5 }; 
        var text= P11.EncodeModified(ints).Pipe(ToText);
        Assert.Equal(text, "(Multiple 4 0) (Single 1) (Multiple 2 2) (Single 3) (Multiple 2 5)");
    }
    [Fact]
    public void TestString() {
        var list = new List<string> { "AAA", "AAA", "BBB", "CCC" };
        var text = P11.EncodeModified(list).Pipe(ToText);
        Assert.Equal(text, "(Multiple 2 AAA) (Single BBB) (Single CCC)"); 
    }
}