(Int64, Int64) run(Int64[] data, Int64 target) {

    IEnumerable<Int64> range(Int64 s, Int64 e) {
        for (var i = s ; i <= e; i++) {
            yield return i;
        }
    };

    (Int64, Int64) process() {
        var len = data.Count();
        var ans = 0L;
        var dff = Int64.MaxValue;
        foreach(var i1 in range(0, len - 3))
        foreach(var i2 in range(i1 + 1, len - 2))
        foreach(var i3 in range(i2 + 1, len - 1)) {
            var a1 = data[i1];
            var a2 = data[i2];
            var a3 = data[i3];
            var p = a1 * a2 * a3;
            //Console.WriteLine("{0} * {1} * {2}", a1,a2,a3);
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

void show(Int64[] data, Int64 target) {
    var rs = run(data, target);
    Console.WriteLine(rs.Item1);
}

// Example
var exTarget = 25;
var exData = new List<Int64> { 1, 2, 3, 4, 5 }.ToArray();

// Small case
var smallTarget = 29592974112914;
var smallData = File.ReadAllLines("SmallCase.txt").Select(clean).ToArray();

// Large case
var largeTarget = 30470556801191;
var largeData = File.ReadAllLines("LargeCase.txt").Select(clean).ToArray();

show(exData, exTarget);
//show(smallData, smallTarget);
show(largeData, largeTarget);