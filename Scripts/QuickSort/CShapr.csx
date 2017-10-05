IEnumerable<int> quick(IEnumerable<int> ls) {
    if (ls.Count() > 0) {
        var head = ls.First();
        return quick(ls.Where(x => x < head)) 
            .Concat(ls.Where(x => x == head)) 
            .Concat(quick(ls.Where(x => x > head)));
    } else {
        return Enumerable.Empty<int>();
    }
}

var rs = quick(new [] { 1,99,2,98,3,97,4,96,4,95,5,94 });
Console.WriteLine(String.Join(",", rs));