using System;
using System.Collections.Generic;
using System.Linq;

namespace _15_August_2020_The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] inicialSongs = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                Song song = new Song();
                song.Name = inicialSongs[0];
                song.Composer = inicialSongs[1];
                song.Key = inicialSongs[2];

                songs.Add(song);
            }

            string[] cmd = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            while (cmd[0] != "Stop")
            {
                switch (cmd[0])
                {
                    case "Add":

                        if (songs.Exists(c => c.Name == cmd[1]))
                        {
                            Console.WriteLine($"{cmd[1]} is already in the collection!");
                        }
                        else
                        {
                            Song song = new Song();
                            song.Name = cmd[1];
                            song.Composer = cmd[2];
                            song.Key = cmd[3];

                            songs.Add(song);

                            Console.WriteLine($"{cmd[1]} by {cmd[2]} in {cmd[3]} added to the collection!");
                        }

                        break;
                    case "Remove":

                        if (songs.Exists(c => c.Name == cmd[1]))
                        {
                            int index = songs.FindIndex(c => c.Name == cmd[1]);
                            songs.RemoveAt(index);

                            Console.WriteLine($"Successfully removed {cmd[1]}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {cmd[1]} does not exist in the collection.");
                        }

                        break;
                    case "ChangeKey":

                        if (songs.Exists(c => c.Name == cmd[1]))
                        {
                            int index = songs.FindIndex(c => c.Name == cmd[1]);
                            songs[index].Key = cmd[2];

                            Console.WriteLine($"Changed the key of {cmd[1]} to {cmd[2]}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {cmd[1]} does not exist in the collection.");
                        }
                        break;

                    default:
                        break;
                }
                cmd = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            }
            songs = songs.OrderBy(c => c.Name).ThenBy(c => c.Composer).ToList();

            foreach (var item in songs)
            {
                Console.WriteLine($"{item.Name} -> Composer: {item.Composer}, Key: {item.Key}");
            }

        }
        class Song
        {
            public string Name { get; set; }
            public string Composer { get; set; }
            public string Key { get; set; }
        }
    }
}
