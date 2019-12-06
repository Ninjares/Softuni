using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Song")]
    public class SongDTO
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public string CreatedOn { get; set; }
        public string Genre { get; set; }
        public int AlbumId { get; set; }
        public int WriterId { get; set; }
        public decimal Price { get; set; }
    }
}
