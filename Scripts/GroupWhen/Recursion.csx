

void m(int x) {
    if (x > 0) {
        Console.WriteLine(x);
        m(x - 1);
        Console.WriteLine(x);
    }
}

m(5);