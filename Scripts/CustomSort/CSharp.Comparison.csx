int[] array = new int[] { 9,9,54,100,7, 2 };
Array.Sort<int>(array, new Comparison<int>( (c1, c2) => c2.CompareTo(c1)));

Console.WriteLine(string.Join(",", array));