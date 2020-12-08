using System;
using System.Collections.Generic;

namespace _03._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();
            Song song = new Song();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split("_");

                song = new Song();

                song.TypeList = data[0];
                song.Name = data[1];
                song.Time = data[2];

                songs.Add(song);

            }
            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Song item in songs)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                foreach (Song item in songs)
                {
                    if (item.TypeList == typeList)
                    {
                        Console.WriteLine(item.Name);
                    }
                    
                }
            }
        }
    }
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }

}

