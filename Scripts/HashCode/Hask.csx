var h1 = 1;
var h2 = 2;
//var seed = Guid.NewGuid().GetHashCode();
var rol5 = h1 << 5 | h1 >> 27;
var x = (rol5 + h1) ^ h2;
Console.WriteLine(x);