const int limit = 331;
var data = new[] { 2, 45, 67, 119, 1, 14, 299 }.OrderByDescending(m => m).ToList();

void findGroupRecursive(List<int> numList, int target, List<int> group) {
    if (group.Sum() > target) return;
    if (group.Count >= 2 && group.Sum() <= target)
        Console.WriteLine($"({String.Join(", ", group.Select(x => x.ToString()).ToArray())})");

    for (int i = 0; i < numList.Count; i++) {
        var nextGroup = new List<int>(group);
        nextGroup.Add(numList[i]);

        var rest = new List<int>();
        for (int j = i + 1; j < numList.Count; j++) rest.Add(numList[j]);

        findGroupRecursive(rest, target, nextGroup);
    }
}

findGroupRecursive(data, limit, new List<int>());