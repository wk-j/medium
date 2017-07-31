

string bin(uint x) => 
    Convert.ToString(x, 2).PadLeft(32, '0')
        .Insert(8, "-")
        .Insert(16 + 1, "-")
        .Insert(24 + 2, "-");

uint x = 1_000;
var r = 5;
var l = 27;

var a = (uint) x >> r;
var b = (uint) x << l;
var c = a | b;

Console.WriteLine("{2, 35} {0} = {1}", bin(x),x, $"{x} => ");
Console.WriteLine("{2, 35} {0} = {1}", bin(a),a, $"{x} >> {r} => ");
Console.WriteLine("{2, 35} {0} = {1}", bin(b),b, $"{x} << {l} => ");
Console.WriteLine("{2, 35} {0} = {1}", bin(c),c, $"{x} >> {r} | {x} << {l} => ");
