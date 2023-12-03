public record struct GameRound (int Red, int Green, int Blue)
{
    public int Power => Red * Green * Blue;
    public static GameRound Parse (string roundDescription) 
    {
        int red = 0; 
        int green = 0; 
        int blue = 0;
        
        var colors = roundDescription.Split(',');
        foreach (string color in colors) 
        {
            var tokens = color.Trim().Split(' ');
            switch (tokens[1]) 
            {
                case "red": red = int.Parse(tokens[0]); break;
                case "blue": blue = int.Parse(tokens[0]); break;
                case "green": green = int.Parse(tokens[0]); break;
            }
        }
        return new GameRound(red,green,blue);
    }

    public static List<GameRound> ParseGame (string gameDescription) 
    {
        List<GameRound> result = new();
        string[] rounds = gameDescription.Split(':')[1].Trim().Split(';');
        foreach (string round in rounds) 
        {
            result.Add(GameRound.Parse(round.Trim()));
        }
        return result;
    }
}