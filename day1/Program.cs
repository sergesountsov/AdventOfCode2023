string[] input = File.ReadAllLines("input.txt");

Console.WriteLine($"part1 {Part1(input)}");

static ulong Part1(string[] input)
{
    ulong result = 0;
    foreach (string line in input)
    {
        char[] digits = line.Where(Char.IsDigit).ToArray();
        ulong incr = digits.Length switch
        {
            0 => 0,
            _ => Convert.ToUInt32($"{digits[0]}{digits[^1]}"),
        };
        result += incr;
    }

    return result;
}