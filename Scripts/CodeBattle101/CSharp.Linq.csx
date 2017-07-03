(Int64, Int64) run(IEnumerable<Int64> data, Int64 target) {
    var query = 
        from d1 in data
        from d2 in data
        from d3 in data
        where (d1 != d2 && d1 != d3 && d2 != d3)
        let p = d1 * d2 * d3      
        let diff = Math.Abs(target - p)
        select new { P = p, Diff = diff };

    Console.WriteLine(query.Count());
    var rs = query.OrderBy(x => x.Diff).First();
    return (rs.P, rs.Diff);
}

Int64 clean(string x) {
    var tr = x.Trim();
    return Int64.Parse(tr);
}

var smallTarget = 29592974112914;
var smallData = File.ReadAllLines("SmallCase.txt").Select(clean);

var largeTarget = 30470556801191;
var largeData = File.ReadAllLines("LargeCase.txt").Select(clean);

void show(IEnumerable<Int64> data, Int64 target) {
    var rs = run(data, target);
    Console.WriteLine(rs.Item1);
}

var exData = new List<Int64> { 1,2,3,4,5};
var exTarget = 25;

show(exData,    exTarget);
show(smallData, smallTarget);
//show(largeData, largeTarget);