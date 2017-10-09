using System;
using BenchmarkDotNet.Attributes;

public class PTest {
    private const string s = "10";
    private const int i = 10;

    [Benchmark]
    public void EEInt() {
        var k = i == i;
    }

    [Benchmark]
    public void EEString() {
        var x = s == s;
    }

    [Benchmark]
    public void REString() {
        var x = Object.ReferenceEquals(s,s);
    }
}