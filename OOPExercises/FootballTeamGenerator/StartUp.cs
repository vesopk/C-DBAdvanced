using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main()
    {
        var teams = new Dictionary<string, Team>();
        string input;
        while (!(input = Console.ReadLine()).Equals("END"))
        {
            var inputParams = input.Split(';').ToList();
            var command = inputParams[0];
            inputParams.RemoveAt(0);
            try
            {
                if (command == "Team")
                {
                    var teamName = inputParams[0];
                    var team = new Team(teamName);
                    teams.Add(teamName, team);
                }
                else if (command == "Add")
                {
                    var teamName = inputParams[0];

                    if (teams.ContainsKey(teamName))
                    {
                        var playerName = inputParams[1];
                        var endurance = int.Parse(inputParams[2]);
                        var sprint = int.Parse(inputParams[3]);
                        var dribble = int.Parse(inputParams[4]);
                        var passing = int.Parse(inputParams[5]);
                        var shooting = int.Parse(inputParams[6]);
                        var player = new Player(playerName,endurance,sprint,dribble,passing,shooting);
                        teams[teamName].Add(player);
                    }
                    else
                    {
                        throw new ArgumentException($"Team {teamName} does not exist.");
                    }

                }
                else if (command == "Remove")
                {
                    var teamName = inputParams[0];
                    var playerName = inputParams[1];
                    if (!teams.ContainsKey(teamName))
                    {
                        throw new ArgumentException($"Team {teamName} does not exist.");
                    }
                    else
                    {
                        teams[teamName].Remove(playerName);
                    }
                }
                else if (command == "Rating")
                {
                    var teamName = inputParams[0];
                    if (teams.ContainsKey(teamName))
                    {
                        teams[teamName].PrintRating();
                    }
                    else
                    {
                        throw new ArgumentException($"Team {teamName} does not exist.");
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

