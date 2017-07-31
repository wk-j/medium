
IEnumerable<IEnumerable<T>> groupWhen<T>( Func<T, int, bool> f, IEnumerable<T> input) {
    var index = - 1;
    var running = true;
    var en = input.GetEnumerator();
    IEnumerable<T> group() {
        Console.WriteLine(en.Current);
        yield return en.Current;
        if(en.MoveNext()) {
            index ++;
            if  (!f(en.Current, index)) 
                foreach(var g in group()) yield return g;
        }else { 
            running = false;
        }
    }
    if (en.MoveNext()) {
        index ++;
        while (running) yield return group();
    }
}

var a = new [] { "Hek", "John", "John", "J" };
var rs = groupWhen((x,i) => x == "John" , a);
Console.WriteLine(string.Join(" -- ", rs.Select(x => string.Join("|", x))));