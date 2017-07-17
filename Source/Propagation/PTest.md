// * Summary *

BenchmarkDotNet=v0.10.8, OS=Mac OS X 10.12
Processor=Intel Core i5-3210M CPU 2.50GHz (Ivy Bridge), ProcessorCount=4
Frequency=1000000000 Hz, Resolution=1.0000 ns, Timer=UNKNOWN
dotnet cli version=1.0.3
  [Host]     : .NET Core 4.6.25009.03, 64bit RyuJIT
  DefaultJob : .NET Core 4.6.25009.03, 64bit RyuJIT


        Method |           Mean |       Error |      StdDev |
-------------- |---------------:|------------:|------------:|
      Standard |       7.849 ns |   0.0944 ns |   0.0788 ns |
 WithAndReturn |      23.062 ns |   0.2244 ns |   0.1989 ns |
      TryCatch | 140,209.059 ns | 826.2965 ns | 772.9182 ns |

// * Hints *
Outliers
  PTest.Standard: Default      -> 2 outliers were removed
  PTest.WithAndReturn: Default -> 1 outlier  was  removed

// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  1 ns   : 1 Nanosecond (0.000000001 sec)

// ***** BenchmarkRunner: End *****