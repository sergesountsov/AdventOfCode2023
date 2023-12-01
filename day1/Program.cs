string[] input = File.ReadAllLines("input.txt");

Console.WriteLine($"part1 {Part1(input)}");
Console.WriteLine($"part2 {Part2(input)}");

static ulong Part2(string[] input)
{
    static bool IsDigitName (ReadOnlySpan<char> str, out uint digit) 
    {
        digit =0;
        (string name, uint digit) [] nameToDigit =  
        {
            ("one", 1),
            ("two", 2),
            ("three", 3),
            ("four", 4),
            ("five", 5),
            ("six", 6),
            ("seven", 7),
            ("eight", 8),
            ("nine", 9)
        };
        foreach (var pair in nameToDigit) 
        {
            if (str.StartsWith(pair.name)) 
            {
                digit = pair.digit;
                return true;
            }
        }
        return false;
    }

    ulong result = 0;
    foreach (string line in input) 
    {
        List<uint> digits = new();
        for (int startPos =0; startPos < line.Length; startPos++) 
        {
            if (Char.IsDigit(line[startPos])) 
            {
                digits.Add(uint.Parse(line.AsSpan(startPos,1)));
            } 
            else if ( IsDigitName(line.AsSpan(startPos), out uint digit)) 
            {
                digits.Add(digit);
            }
        }
        result += digits.Count switch {
            0 => 0,
            1 => digits[0],
            _ => digits[0]*10 + digits[^1]
        };
    }
    return result;
}

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