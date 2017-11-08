using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class InvalidSongException : Exception
    {
        private string exceptionMessage = "Invalid song.";

        protected virtual string ExceptionMessage
        {
            set
            {
                this.exceptionMessage = value;
            }
        }

        public override string Message => exceptionMessage;
    }

    class InvalidArtistNameException : InvalidSongException
    {
        public override string Message => "Artist name should be between 3 and 20 symbols.";
    }

    class InvalidSongNameException : InvalidSongException
    {
        public override string Message => "Song name should be between 3 and 30 symbols.";
    }

    class InvalidSongLengthException : InvalidSongException
    {
        public override string Message => "Invalid song length.";
    }

    class InvalidSongMinutesException : InvalidSongLengthException
    {
        public override string Message => "Song minutes should be between 0 and 14.";
    }

    class InvalidSongSecondsException : InvalidSongLengthException
    {
        public override string Message => "Song seconds should be between 0 and 59.";
    }

    class Song
    {
        // <artist name>;<song name>;<minutes:seconds>

        private string name;
        private string songName;
        private int minutes;
        private int seconds;
        private int totalLength;




        public Song(string name, string songName, int minutes, int seconds)
        {
            this.Name = name;
            this.SongName = songName;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public int Seconds
        {
            get { return seconds; }
            set
            {
                //Song seconds should be between 0 and 59."
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }
                seconds = value;
            }
        }

        public int Minutes
        {
            //Song minutes should be between 0 and 14.
            get { return minutes; }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }
                this.minutes = value;
            }
        }

        public string SongName
        {
            //•	Song name should be between 3 and 30 symbols.
            get { return songName; }
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }
                this.songName = value;
            }
        }

        public string Name
        {
            //•	Artist name should be between 3 and 20 symbols
            get { return name; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }
                this.name = value;
            }
        }

    }

class Program
{
    static void Main(string[] args)
    {
        List<Song> songs = new List<Song>();
        int attempts = int.Parse(Console.ReadLine());

        for (int i = 0; i < attempts; i++)
        {
            // ABBA;Mamma Mia;3:35
            string[] input = Console.ReadLine().ToLower().Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            try
            {
                //if (string.IsNullOrWhiteSpace(input[0]) && string.IsNullOrWhiteSpace(input[1]))
                //{
                //    throw new InvalidSongException();
                //}

                //if ((input[0].Length <3 && input[1].Length<3)|| (input[0].Length > 20 && input[1].Length > 30))
                //{
                //    throw new InvalidSongException();
                //}

                string[] time = input[2].Split(':').ToArray();
                int digit1;
                int digit2;
                if (int.TryParse(time[0], out digit1) && int.TryParse(time[1], out digit2))
                {
                    songs.Add(new Song(input[0], input[1], digit1, digit2));
                    Console.WriteLine("Song added.");
                }
                else
                {
                    throw new InvalidSongLengthException();
                }

            }
            catch (Exception ise)
            {
                Console.WriteLine(ise.Message);
            }
        }

        Console.WriteLine($"Songs added: {songs.Count}");

        int totalDuration = 0;
        foreach (var song in songs)
        {
            totalDuration += song.Minutes * 60 + song.Seconds;
        }
        int hours = totalDuration / 3600;
        totalDuration -= hours * 3600;
        int minutes = totalDuration / 60;
        totalDuration -= minutes * 60;
        int seconds = totalDuration;

        Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");



    }
}