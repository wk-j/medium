

public static class ListExtensions {
    public static void Add<T>(this List<T> list, int size, T defaultValue) {
        list.AddRange(Enumerable.Repeat(defaultValue, size));
    }
}

var list = new List<int> {
    { 10, 100 },
    { 10, 200 },
    { 10, 300 }
};

WriteLine(list.Where(x => x == 100).Count() == 10);
WriteLine(list.Where(x => x == 200).Count() == 10);
WriteLine(list.Where(x => x == 300).Count() == 10);


