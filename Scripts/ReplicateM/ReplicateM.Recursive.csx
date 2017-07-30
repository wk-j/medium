IEnumerable<IEnumerable<T>> replicateM<T>(IEnumerable<T> input, int n) {
    if (n == 1) 
        foreach(var x in input) yield return new [] { x };
    else  
        foreach(var x in replicateM(input, n - 1)) 
            foreach(var y in input) 
                yield return x.Concat(new [] { y }); 
}

var result = replicateM(new [] { 1,2 }, 3);
result.Select(x => string.Join(",", x)).ToList().ForEach(Console.WriteLine);

/*
1,1,1
1,1,2
1,2,1
1,2,2
2,1,1
2,1,2
2,2,1
2,2,2
 */