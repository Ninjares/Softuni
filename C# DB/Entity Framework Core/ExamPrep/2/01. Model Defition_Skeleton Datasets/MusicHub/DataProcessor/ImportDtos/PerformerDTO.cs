using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class PerformerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal NetWorth { get; set; }
        [XmlArray]
        public SongPDTO[] PerformersSongs { get; set; }
    }
    [XmlType("Song")]
    public class SongPDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
