
class T {

    public static string Concat(object obj1, object obj2) {
        Console.WriteLine("Input is object");
        return String.Concat(obj1, obj2);
    }

    public static string Concat(DateTime str1, DateTime str2) {
        Console.WriteLine("Input is DateTime");
        return String.Concat(str1, str2);
    }

    public static string Concat(string str1, string str2) {
        Console.WriteLine("Input is string");
        return String.Concat(str1, str2);
    }

    public static void F1<T>(IEnumerable<T> input) {
        Console.WriteLine("IEnumerable");
    }

/*
    public static void F1<T>(List<T> input) {
        Console.WriteLine("List");
    }
    */

    public static void F1<K>(K input) {
        Console.WriteLine("T");
    }

    public static void F1(Object input) {
        Console.WriteLine("Object");
    }

    public static void X(Object obj) {
        Type currentType = obj.GetType();
        while (currentType != null)
        {
            Console.WriteLine(currentType.ToString());
            currentType = currentType.BaseType;
        }
    }
}

//Console.WriteLine(T.Concat(null, null));
T.X(new [] { 1 }.ToList());

T.F1(new [] { 1, 2 });
T.F1(new [] { 1, 2 }.ToList());