class A {
    public int X { set;get;}
    public int Y { set;get;}
}

var a = new A();
var b = new A();

var ha = RuntimeHelpers.GetHashCode(a);
var hb = RuntimeHelpers.GetHashCode(b);

Console.WriteLine(ha);
Console.WriteLine(hb);
