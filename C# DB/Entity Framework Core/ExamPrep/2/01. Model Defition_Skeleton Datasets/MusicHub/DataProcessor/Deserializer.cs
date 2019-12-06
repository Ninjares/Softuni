namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var writers = JsonConvert.DeserializeObject<Writer[]>(jsonString);
            foreach(Writer writer in writers)
            {
                if (IsValid(writer))
                {
                    context.Writers.Add(writer);
                    sb.AppendLine(String.Format(SuccessfullyImportedWriter, writer.Name));
                }
                else sb.AppendLine(ErrorMessage);
            }
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var producers = JsonConvert.DeserializeObject<ProducerDTO[]>(jsonString);
            foreach(ProducerDTO producerDTO in producers)
            {
                Producer producer = new Producer
                {
                    Name = producerDTO.Name,
                    Pseudonym = producerDTO.Pseudonym,
                    PhoneNumber = producerDTO.PhoneNumber
                };
                if (IsValid(producer))
                {
                    bool allgood = true;
                    List<Album> albums = new List<Album>();
                    foreach (AlbumDTO albumDTO in producerDTO.Albums)
                    {
                        Album album = new Album
                        {
                            Name = albumDTO.Name,
                            ReleaseDate = DateTime.ParseExact(albumDTO.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            Producer = producer
                        };
                        if (IsValid(album)) albums.Add(album);
                        else { allgood = false; break; }
                    }
                    if (allgood)
                    {
                        context.Producers.Add(producer);
                        context.Albums.AddRange(albums);
                        if(producer.PhoneNumber == null)
                            sb.AppendLine(String.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, albums.Count));
                        else
                        sb.AppendLine(String.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, albums.Count));
                    }
                    else sb.AppendLine(ErrorMessage);
                }
                else sb.AppendLine(ErrorMessage);
            }
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(SongDTO[]), new XmlRootAttribute("Songs"));
            var songDtos = (SongDTO[])serializer.Deserialize(new StringReader(xmlString));
            foreach(SongDTO songDTO in songDtos)
            {
                if (context.Albums.FirstOrDefault(x => x.Id == songDTO.AlbumId) == null || context.Writers.FirstOrDefault(x => x.Id == songDTO.WriterId) == null || songDTO.Genre == "Invalid")
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    //Song song = AutoMapper.Mapper.Map<Song>(songDTO);
                    //var span = TimeSpan.Parse(songDTO.Duration);
                    Song song = new Song
                    {
                        Name = songDTO.Name,
                        Duration = TimeSpan.Parse(songDTO.Duration),
                        CreatedOn = DateTime.ParseExact(songDTO.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Genre = (Genre)Enum.Parse(typeof(Genre), songDTO.Genre),
                        AlbumId = songDTO.AlbumId,
                        WriterId = songDTO.WriterId,
                        Price = songDTO.Price

                    };
                    if (IsValid(song))
                    {
                        context.Songs.Add(song);
                        sb.AppendLine(String.Format(SuccessfullyImportedSong, song.Name, song.Genre.ToString(), song.Duration.ToString()));
                    }
                    else sb.AppendLine(ErrorMessage);
                }
            }
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(PerformerDTO[]), new XmlRootAttribute("Performers"));
            var perfDtos = (PerformerDTO[])serializer.Deserialize(new StringReader(xmlString));
            foreach(var perfDto in perfDtos)
            {
                Performer performer = new Performer
                {
                    FirstName = perfDto.FirstName,
                    LastName = perfDto.LastName,
                    Age = perfDto.Age,
                    NetWorth = perfDto.NetWorth
                };
                if (IsValid(performer) && perfDto.PerformersSongs.All(x => context.Songs.Any(s => s.Id == x.Id)))
                {
                    context.Performers.Add(performer);
                    foreach (var songid in perfDto.PerformersSongs)
                    {
                        SongPerformer songPerformer = new SongPerformer
                        {
                            Performer = performer,
                            Song = context.Songs.FirstOrDefault(x => x.Id == songid.Id)
                        };
                        context.SongPerformers.Add(songPerformer);
                    }
                    sb.AppendLine(String.Format(SuccessfullyImportedPerformer, performer.FirstName, perfDto.PerformersSongs.Length));
                }
                else sb.AppendLine(ErrorMessage);
            }
            context.SaveChanges();
            return sb.ToString();
        }

        private static bool IsValid(object obj)
        {
            return Validator.TryValidateObject(obj, new System.ComponentModel.DataAnnotations.ValidationContext(obj), new System.Collections.Generic.List<ValidationResult>(), true);
        }
    }
}