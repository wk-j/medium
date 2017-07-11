
class T {
    public static void F1<T>(IEnumerable<T> input) {
        Console.WriteLine("IEnumerable<T>");
    }

    public static void F1<T>(T[] input) {
        Console.WriteLine("Array<T>");
    }

    public static void F1<T>(T input) {
        Console.WriteLine("T");
    }

    public static void F1(Object input) {
        Console.WriteLine("Object");
    }
}

T.F1(new [] { 1 });
T.F1(1);
T.F1(Enumerable.Empty<int>());