namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

           DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportAlbumsInfo(context, 9));

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .ToList()
                .Where(x => x.ProducerId == producerId)
                .Select(x => new
                {
                    AlbumName = x.Name,
                    x.ReleaseDate,
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(x => new
                    {
                        SongName = x.Name,
                        x.Price,
                        WriterName = x.Writer.Name
                    })
                    .OrderByDescending(x => x.SongName)
                    .ThenBy(x => x.WriterName)
                    .ToList(),
                    AlbumPrice = x.Songs.Sum(x => x.Price),
                })
                .OrderByDescending(x => x.AlbumPrice)
                .ToList();


            foreach (var item in albums)
            {
                int count = 0;

                sb.AppendLine($"-AlbumName: {item.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {item.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {item.ProducerName}");
                sb.AppendLine($"-Songs:");

                foreach (var song in item.Songs)
                {
                    count++;

                    sb.AppendLine($"---#{count}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }
                sb.AppendLine($"-AlbumPrice: {item.AlbumPrice:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {

            var songs = context.Songs
                .ToList()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new 
                {
                    SongName = x.Name,
                    WriterName = x.Writer.Name,
                    Performer = x.SongPerformers.Select(x => 
                    x.Performer.FirstName + " " + x.Performer.LastName)
                    .FirstOrDefault(),
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration

                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.Performer)
                .ToList();

            StringBuilder sb = new StringBuilder();
            int count = 0;

            foreach (var item in songs)
            {
                count++;

                sb.AppendLine($"-Song #{count}");
                sb.AppendLine($"---SongName: {item.SongName}");
                sb.AppendLine($"---Writer: {item.WriterName}");
                sb.AppendLine($"---Performer: {item.Performer}");
                sb.AppendLine($"---AlbumProducer: {item.AlbumProducer}");
                sb.AppendLine($"---Duration: {item.Duration}");


            }

            return sb.ToString().Trim();
        }
    }
}
