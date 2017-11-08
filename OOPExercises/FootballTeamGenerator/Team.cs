using System;
using System.Collections.Generic;
using System.Linq;


public class Team
{
    private string name;
    private Dictionary<string,Player> players;

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public Team(string name)
    {
        Name = name;
        this.players = new Dictionary<string, Player>();
    }

    public void Add(Player player)
    {
        if (!players.ContainsKey(player.Name))
        {
            this.players.Add(player.Name,player);
        }
    }

    public void Remove(string player)
    {
        if (players.ContainsKey(player))
        {
            this.players.Remove(player);
        }
        else
        {
            throw new ArgumentException($"Player {player} is not in {name} team.");
        }
    }

    public void PrintRating()
    {
        if (players.Any())
        {
            var result = players.Sum(p => p.Value.Rating) / players.Count;
            Console.WriteLine($"{name} - {result}");
        }
        else
        {
            Console.WriteLine($"{name} - 0");
        }
    }

}
