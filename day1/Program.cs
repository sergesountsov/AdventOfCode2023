string[] input = File.ReadAllLines("input.txt");
ulong result = 0;
foreach (string line in input) {
    char[] digits = line.Where(Char.IsDigit).ToArray();
    result += digits.Length switch {
        0 => 0,
        1 => Convert.ToUInt32(digits[0]),
        _ => Convert.ToUInt32(digits[0]+digits[^1]),
    };
    
}
Console.WriteLine($"part1 {result}");
