namespace _1000Counter.Models;

public class GameViewModel
{
    public List<Player> Players { get; set; } = new List<Player>();
    public int CurrentRound { get; set; } = 1;
}

