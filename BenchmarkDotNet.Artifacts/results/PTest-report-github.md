``` ini

BenchmarkDotNet=v0.10.8, OS=Mac OS X 10.12
Processor=Intel Core i5-3210M CPU 2.50GHz (Ivy Bridge), ProcessorCount=4
Frequency=1000000000 Hz, Resolution=1.0000 ns, Timer=UNKNOWN
dotnet cli version=1.0.3
  [Host]     : .NET Core 4.6.25009.03, 64bit RyuJIT
  DefaultJob : .NET Core 4.6.25009.03, 64bit RyuJIT


```
 |        Method |           Mean |       Error |      StdDev |
 |-------------- |---------------:|------------:|------------:|
 |      Standard |       7.110 ns |   0.1352 ns |   0.1198 ns |
 | WithAndReturn |      23.490 ns |   0.1750 ns |   0.1551 ns |
 |      TryCatch | 145,661.695 ns | 558.1437 ns | 494.7798 ns |
