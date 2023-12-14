// Team Class
using System.Collections.Generic;
using System.Linq;

public class Team
{
    public string Name { get; set; }
    public List<Player> Players { get; set; }

    public int TeamPoints
    {
        get { return Players.Sum(player => player.Points); }
    }

    public override string ToString()
    {
        return $"{Name} - Points: {TeamPoints}";
    }
}
