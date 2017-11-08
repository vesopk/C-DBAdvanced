using System;

public class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;
    private double rating;

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

    public int Passing
    {
        get => this.endurance;
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Passing should be between 0 and 100.");
            }
            this.passing = value;
        }
    }

    public int Endurance
    {
        get => this.endurance;
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Endurance should be between 0 and 100.");
            }
            this.endurance = value;
        }
    }

    public int Sprint
    {
        get => this.sprint;
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Sprint should be between 0 and 100.");
            }
            this.sprint = value;
        }
    }

    public int Dribble
    {
        get => this.dribble;
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Dribble should be between 0 and 100.");
            }
            this.dribble = value;
        }
    }

    public int Shooting
    {
        get => this.shooting;
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Shooting should be between 0 and 100.");
            }
            this.shooting = value;
        }
    }

    public double Rating
    {
        get => this.rating;
    }
    private double SetRating()
    {
        var avg = (this.endurance + this.dribble + this.sprint + this.shooting + this.passing) / 5.0;
        var result = Math.Round(avg);
        return result;
    }

    public Player(string name, int endurance, int sprint, int dribble,int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Shooting = shooting;
        Passing = passing;
        this.rating = SetRating();
    }
}
