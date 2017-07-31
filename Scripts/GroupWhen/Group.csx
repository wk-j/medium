
IEnumerable<IEnumerable<T>> groupWhen<T>( Func<T, int, bool> f, IEnumerable<T> input) {
    var index = - 1;
    var running = true;
    var en = input.GetEnumerator();

    IEnumerable<T> group() {
        Console.Write("-" + en.Current);
        yield return en.Current;
        if(en.MoveNext()) {
            index ++;
            if  (!f(en.Current, index)) { 
                foreach(var g in group())  {
                    Console.Write("+" + g);
                    yield return g;
                }
                Console.WriteLine();
            }
        }else { 
            Console.WriteLine(".");
            running = false;
        }
    }
    if (en.MoveNext()) {
        index ++;
        while (running) yield return group();
    }
}

var a = new [] { 1,2,3,4,5,6 };
var rs = groupWhen((x,i) => x == 3 , a);
Console.WriteLine(string.Join(" - ", rs.Select(x => string.Join("+", x))));