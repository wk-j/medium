
class T {
    public static string Concat(long a1, long a2) {
        Console.WriteLine("Input is long");
        return String.Concat(a1,a2);
    }

    public static string Concat(int? a1, int? a2) {
        Console.WriteLine("Input is int");
        return String.Concat(a1,a2);
    }

    public static string Concat(string a1, string a2) {
        Console.WriteLine("Input is string");
        return String.Concat(a1, a2);
    } 

    public static string Concat(object a1, object a2) {
        Console.WriteLine("Input is object");
        return String.Concat(a2, a1);
    }
}

T.Concat(null, null);
