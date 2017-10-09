int mn<T>(T a1, T a2) where T: IComparable => a2.CompareTo(a1);
var a = new List<int> { 1,2,3,4,5 };
a.Sort(mn);

Console.WriteLine(string.Join(",", a));
