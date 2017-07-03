using Medium;
using System.Collections.Generic;
using Xunit;

public class HeadTailFacts {
    [Fact]
    public void T() {
        var list = new List<int> { 1,2,3,4,5 };
        var (h,t) = list;
    }
}