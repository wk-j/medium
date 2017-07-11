
class T {

    public static string Concat(string str1, string str2) {
        Console.WriteLine("Input is string");
        return String.Concat(str1, str2);
    }

    public static string Concat(object obj1, object obj2) {
        Console.WriteLine("Input is object");
        return String.Concat(obj1, obj2);
    }

    public static void F1<T>(IEnumerable<T> input) {
        Console.WriteLine("IEnumerable");
    }

    public static void F1<T>(T input) {
        Console.WriteLine("Object");
    }

    public static void F1(string input) {
        Console.WriteLine("String");
    }

}

//var s = null;
var rs = T.Concat(null, null);
T.Concat(1, null);

T.F1("");
T.F1(new [] { 1 });

string.Concat(null, null);