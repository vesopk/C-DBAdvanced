using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Song
{
    private string group;
    private string name;
    private TimeSpan duration;

    public string Group
    {
        get => this.group;
        private set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException(SongsExceptions.InvalidArtistNameException);
            }
            this.group = value;
        }
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException(SongsExceptions.InvalidSongException);
            }
            this.name = value;
        }
    }
}
