namespace MusicHub.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        static XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var toJson = context.Albums.Where(x => x.ProducerId == producerId).OrderByDescending(x => x.Price).Select(x => new
            {
                AlbumName = x.Name,
                ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                ProducerName = x.Producer.Name,
                Songs = x.Songs.Select(s => new
                {
                    SongName = s.Name,
                    Price = s.Price.ToString("F2"),
                    Writer = s.Writer.Name
                }).OrderByDescending(s => s.SongName).ThenBy(s => s.Writer).ToArray(),
                AlbumPrice = x.Price.ToString("F2")
            });
            return JsonConvert.SerializeObject(toJson, Newtonsoft.Json.Formatting.Indented);
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs.Where(x => x.Duration.TotalSeconds > duration).Select(x => new SongDTO
            {
                SongName = x.Name,
                Writer = x.Writer.Name,
                Performer = x.SongPerformers.FirstOrDefault().Performer.FirstName + " " + x.SongPerformers.FirstOrDefault().Performer.LastName,
                AlbumProducer = x.Album.Producer.Name,
                Duration = x.Duration.ToString("c")

            }).OrderBy(x => x.SongName).ThenBy(x => x.Writer).ThenBy(x => x.Performer).ToArray();
            var serializer = new XmlSerializer(typeof(SongDTO[]), new XmlRootAttribute("Songs"));
            using(TextWriter tw = new StringWriter())
            {
                serializer.Serialize(tw, songs, namespaces);
                return tw.ToString();
            }
        }
    }
}