class FilePath {
    public FilePath(string path) => Path = path;
    public string Path { get; }

    // implicit conversion
    public static implicit operator string (FilePath p) => p.Path;
    public static implicit operator FilePath (String p) => new FilePath(p);

    // operator overloading
    public static FilePath operator / (String s, FilePath p) => 
        new FilePath(System.IO.Path.Combine(s, p.Path));

    public static FilePath operator / (FilePath s, string p) =>
        new FilePath(System.IO.Path.Combine(s, p));

    public static FilePath operator / (FilePath s, FilePath p) =>
        new FilePath(System.IO.Path.Combine(s,p));
}

// test
var root = new FilePath("Dir0");
var targetA = root / "Dir1" / "Dir2" / "Dir3" / "HelloWorld.txt";
var targetB = System.IO.Path.Combine(root, "Dir1", "Dir2", "Dir3", "HelloWorld.txt");

Console.WriteLine(targetA);    // Dir0/Dir1/Dir2/Dir3/HelloWorld.txt
Console.WriteLine(targetB);    // Dir0/Dir1/Dir2/Dir3/HelloWorld.txt