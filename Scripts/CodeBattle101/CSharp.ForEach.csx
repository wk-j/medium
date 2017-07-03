(Int64, Int64) run(IEnumerable<Int64> data, Int64 target) {
    (Int64, Int64) process() {
        var div = data.Count() / 2 + 1;
        var ans = 0L;
        var dff = Int64.MaxValue;
        foreach (var a1 in data.Take(div))
            foreach (var a2 in data.Where(x => x != a1))
                foreach (var a3 in data.Where(x => x != a1 && x != a2)) {
                    var p = a1 * a2 * a3;
                    var diff = Math.Abs(target - p);
                    if (diff < dff) {
                        dff = diff;
                        ans = p;
                    }
                }
        return (ans, dff);
    };
    return process();
}

Int64 clean(string x) {
    var tr = x.Trim();
    return Int64.Parse(tr);
}

void show(IEnumerable<Int64> data, Int64 target) {
    var rs = run(data, target);
    Console.WriteLine(rs.Item1);
}

// Example
var exTarget = 25;
var exData = new List<Int64> { 1, 2, 3, 4, 5 };

// Small case
var smallTarget = 29592974112914;
var smallData = File.ReadAllLines("SmallCase.txt").Select(clean);

// Large case
var largeTarget = 30470556801191;
var largeData = File.ReadAllLines("LargeCase.txt").Select(clean);

show(exData, exTarget);
show(smallData, smallTarget);
show(largeData, largeTarget);