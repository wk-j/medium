
using System.Runtime.CompilerServices;
using System.Reflection;

var lazy = new Lazy<int>(() => 1 + 1);
Console.WriteLine(lazy.Value);

