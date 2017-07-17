class FilePath {

    public FilePath(string path) => Path = path;

    public string Path { get; }

    public static implicit operator string (FilePath p) => p.Path;
    public static implicit operator FilePath (String p) => new FilePath(p);

    public static FilePath operator / (String s, FilePath p) => 
        new FilePath(System.IO.Path.Combine(s, p.Path));

    public static FilePath operator / (FilePath s, string p) =>
        new FilePath(System.IO.Path.Combine(s, p));

    public static FilePath operator / (FilePath s, FilePath p) =>
        new FilePath(System.IO.Path.Combine(s,p));
    
    public bool IsDirectory() => System.IO.Directory.Exists(Path);
    public bool IsFile() => System.IO.File.Exists(Path);
    public bool Exists() => System.IO.File.Exists(Path) || System.IO.Directory.Exists(Path);
}

var root = new FilePath("/");
FilePath x = root / "hello" / "world";
Console.WriteLine(x.Exists());
Console.WriteLine(x);

string k = root / "hello" / "world";
Console.WriteLine(k);