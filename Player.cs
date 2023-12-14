// Player Class
using System;

public class Player
{
    public string Name { get; set; }
    public string ResultRecord { get; set; }

    public int Points
    {
        get
        {
            // Implement the logic to calculate points based on the last 5 results
            int points = 0;
            int startIndex = Math.Max(0, ResultRecord.Length - 5);

            foreach (char result in ResultRecord.Substring(startIndex))
            {
                if (result == 'W') points += 3;
                else if (result == 'D') points += 1;
            }

            return points;
        }
    }


    public override string ToString()
    {
        return $"{Name} - {ResultRecord}";
    }
}

