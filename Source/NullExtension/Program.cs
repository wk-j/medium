
using System;

static class Extension
{
    public static void PrintHello2(this Example _)
    {
        Console.WriteLine("Hello 2");
    }
}
public class Example
{
    static void PrintHello1()
    {
        Console.WriteLine("Hello 1");
    }
    static void Main(string[] args)
    {
        Example.PrintHello1();  // Hello 1

        Example example = null;
        example.PrintHello2();  // Hello 2
    }
}

