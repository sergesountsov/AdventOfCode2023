namespace day3;

public class UnitTest1
{
    [Fact]
    public void Return_One_Number()
    {
        string[] input = {
            "...+12.."
        };
        var actual = Part1_Numbers(input);
        Assert.Equal(new List<int>{12}, actual);
    }

    [Fact]
    public void Number_No_Symbol() {
        string[] input = {
            "....12.."
        };
        var actual = Part1_Numbers(input);
        Assert.Equal(new List<int>(), actual);
    }

    [Fact]
    public void One_Number_Symbol_End() {
        string[] input = {
            @"....12\"
        };
        var actual = Part1_Numbers(input);
        Assert.Equal(new List<int> {12}, actual);
    }

    [Fact]
    public void One_Number_Symbol_PreviosLine() {
        string[] input = {
            @"...+....",
            @"....12.."
        };
        var actual = Part1_Numbers(input);
        Assert.Equal(new List<int> {12}, actual);
    }
    
    [Fact]
    public void One_Number_Symbol_at_NE() {
        string[] input = {
            @"......+",
            @"....12."
        };
        var actual = Part1_Numbers(input);
        Assert.Equal(new List<int> {12}, actual);
    }

    [Fact]
    public void One_Number_Symbol_NextLine() {
        string[] input = {
            @"......12",
            @".......+"
        };
        var actual = Part1_Numbers(input);
        Assert.Equal(new List<int> {12}, actual);
    }

    [Fact]
    public void Part1_Example() {
        string[] input = {
            @"467..114..",
            @"...*......",
            @"..35..633.",
            @"......#...",
            @"617*......",
            @".....+.58.",
            @"..592.....",
            @"......755.",
            @"...$.*....",
            @".664.598.."
        };
        var actual = Part1_Numbers(input);
        Assert.Equal(new List<int> {467, 35, 633, 617, 592, 755, 664, 598}, actual);
        var count = actual.Aggregate(0, (acc, n) => acc + n);
        Assert.Equal(4361, count);
    }

    [Fact]
    public void Part1_Full () 
    {
        string[] input = File.ReadAllLines("input.txt");
        var result = Part1_Numbers(input).Aggregate(0, (acc, n) => acc + n);
        var str_result = string.Join(", ", Part1_Numbers(input));
        Console.WriteLine(str_result);
        Console.WriteLine ($"Part1 {result}");
    }
    List<int> Part1_Numbers(string[] input) 
    {
        List<int> result = new();
        for ( int i = 0; i < input.Length; i++) 
        {
            string line = input[i];
            foreach(ValueMatch m in Regex.EnumerateMatches (line, @"\d+"))
            {
                if (HasSymbol(input, i, m.Index, m.Length )) 
                {
                    result.Add(int.Parse(line.AsSpan(m.Index, m.Length)));
                }
            }
        }
        return result;
    }

    bool HasSymbol(string[] input, int lineId, int start, int len) 
    {
        Regex symbol = new (@"[^.\d]", RegexOptions.NonBacktracking);
        // check previous character
        if (start > 0 && symbol.Count(input[lineId].AsSpan(start - 1, 1)) > 0) 
        {
            return true;
        }
        // check following character
         if (start + len < input[lineId].Length && symbol.Count(input[lineId].AsSpan(start + len, 1)) > 0)
         {
            return true;
         }

        // expand candidate span by 1 from each side
        (start, len) = Expand(input[lineId], start, len);

         // check previous line
        if (lineId > 0 && symbol.Count(input[lineId - 1].AsSpan(start, len)) > 0) 
        {
            return true;
        }

        // check next line
        if (lineId < input.Length - 1 && symbol.Count(input[lineId + 1].AsSpan(start, len)) > 0) 
        {
            return true;
        }

        return false;
    }

    (int start, int len) Expand (string line, int start, int len) 
    {
        start = (start > 0) ? start - 1 : start;
        len = (start + len < line.Length - 1) ? len + 2 : len + 1;
        return (start, len);
    }
}