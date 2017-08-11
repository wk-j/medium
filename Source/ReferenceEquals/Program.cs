using System;
using BenchmarkDotNet;

namespace ReferenceEquals
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<PTest>();
        }
    }
}
