(Int64, Int64) run(IEnumerable<Int64> data, Int64 target) {
    var len = data.Count();
    var sec = len / 3;
    var data1 = data.Take(sec);
    var data2 = data.Skip(sec).Take(sec);
    var data3 = data.Skip(sec * 2 + 3).Take(sec);
    var query = 
        from d1 in data1
        from d2 in data2
        from d3 in data3
        let p = d1 * d2 * d3      
        let diff = Math.Abs(target - p)
        select new { P = p, Diff = diff };
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

show(smallData, smallTarget);
//show(largeData, largeTarget);