using System;
using BenchmarkDotNet;

namespace ReferenceEquals
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<PTest>();
        }
    }
}
