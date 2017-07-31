// https://github.com/dotnet/coreclr/pull/1830  

string bin(uint x) => Convert.ToString(x, 2).PadLeft(32, '0');

public int combine(int h1, int h2) {
    unchecked {
        // RyuJIT optimizes this to use the ROL instruction
        // Related GitHub pull request: dotnet/coreclr#1830

        var x5 = (uint) h1 << 5;
        var x27 = (uint) h1 >> 27;

        uint rol5 = ((uint)h1 << 5) | ((uint)h1 >> 27);

        Console.WriteLine($"{bin(x5)}\n{bin(x27)}\n{bin(rol5)}");

        //return ((int)rol5 + h1) ^ h2;
        return (int) rol5;
    }
}

int x = Int32.MaxValue / 4;

Console.WriteLine($"{bin((uint) x)}\n{bin((uint) combine(x,x))}");

