IEnumerable<Result> unfold<State,Result>(State start, Func<State,Tuple<Result,State>> func) {
    var result = func(start);
    yield return result.Item1;
    foreach(var x in unfold<State,Result>(result.Item2, func)) yield return x;
}

var state = new Tuple<int,int>(1,1);
var fib = unfold(state, x => new Tuple<int,Tuple<int,int>>(x.Item2, new Tuple<int,int>(x.Item2, x.Item1 + x.Item2)));
var seq = fib.Take(5);

Console.WriteLine(string.Join(", ", seq));      // 1, 2, 3, 5, 8