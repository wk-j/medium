// https://github.com/dotnet/coreclr/pull/1830

string bin(uint x) => Convert.ToString(x, 2).PadLeft(32, '0');

void str(string title, uint x) {
    Console.WriteLine($"{bin(x)} {x} ({title})");
}

uint h1 = 5;
uint h2 = 6;

str("h1", h1);
str("h2", h2);
str("h1 << 5", h1 << 5);
str("h2 >> 27", h2 >> 27);
str("|", h1 << 5 | h2 >> 27);