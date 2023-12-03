using Xunit;
public class Day2 
{
    [Fact]
    void Part1() 
    {
        string[] input = File.ReadAllLines("input.txt");
        List<List<GameRound>> games = new();
        foreach (string gameDescr in input) 
        {
            games.Add(GameRound.ParseGame(gameDescr));
        }

        Assert.Equal(100, games.Count);

        int result = 0;
        for(int i = 0; i < games.Count; i++) 
        {
            if (games[i].Count(round => round.Red > 12 || round.Green > 13 || round.Blue > 14) == 0) 
            {
                result += i + 1;
            }
        }

        Console.WriteLine($"part1 {result}");
    }

    [Fact]
    void Parse_One_GameRound() 
    {
        GameRound actual = GameRound.Parse("3 red, 5 green, 4 blue");
        Assert.Equal(new GameRound(3,5,4), actual);
    }

    [Fact]
    void Parse_One_Color()
    {
        GameRound actual = GameRound.Parse("3 green");
        Assert.Equal(new GameRound(0,3,0), actual);
    }

    [Fact]
    void ParseGame_OneRound() 
    {
        var actual = GameRound.ParseGame("Game 3: 12 green, 2 blue");
        Assert.Equal(new List<GameRound> {new GameRound(0,12,2)}, actual);
    }

    [Fact]
    void Parse_MultipleRounds() 
    {
        var actual = GameRound.ParseGame("Game 2: 3 green, 18 blue; 14 green, 4 red, 2 blue; 3 red, 14 green, 15 blue");
        Assert.Equal(new List<GameRound> {new GameRound(0,3,18), new GameRound(4,14,2), new GameRound(3,14,15)}, actual);
    }

}

