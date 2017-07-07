#r "../../Source/Medium/bin/Debug/netstandard1.4/Medium.dll"
#r "../../packages/System.Runtime/lib/net462/System.Runtime.dll"

using Medium;

int Double(int i) => i * 2;
string ToString(int i) => i.ToString("D10");

100.Forward(Double).Forward(ToString).Forward(Console.WriteLine);