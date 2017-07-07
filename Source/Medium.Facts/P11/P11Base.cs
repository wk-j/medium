using System;
using System.Collections.Generic;
using System.Linq;

public class C<T> {
    public T E { set;get; }
}

public class Single<T>: C<T> { 
    public Single(T e) => E = e;
    public override string ToString() => $"Single {E}";
}

public class Multiple<T>: C<T> {
    public Multiple(T e, int n) { E = e; N = n; }
    public int N { set;get;}
    public override string ToString() => $"Multiple {N} {E}";
}

static class MyExtensions {
    public static T Pipe<A,T>(this A obj, Func<A,T> func) => func(obj);
}