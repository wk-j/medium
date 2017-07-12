
using System;
using Xunit;

public class Province {
    public string Name { set;get; }
}
public class Address {
    public Province Province { set;get; }
}
public class Person { 
    public Address Address { set;get; }
}

public static class Ext {
    public static Tr With<Ts, Tr>(this Ts o, Func<Ts, Tr> func)
        where Tr : class where Ts : class => o == null ? null : func(o);
    public static Tr Return<Ts,Tr>(this Ts o, Func<Ts, Tr> func, Tr value) 
        where Tr : class where Ts : class => o == null ? value : func(o);
}

public class PropagationFacts {
    [Fact]
    public void Test() {
        var p = new Person();
        var ans1 = p.With(x => x.Address).With(x => x.Province).Return(x => x.Name, "Bangkok");
        var ans2 = p?.Address?.Province?.Name ?? "Bangkok";
        Assert.Equal(ans1, ans2);
    }
}