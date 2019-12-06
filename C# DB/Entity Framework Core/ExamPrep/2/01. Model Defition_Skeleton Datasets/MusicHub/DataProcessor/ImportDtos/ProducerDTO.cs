using System;
using System.Collections.Generic;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ProducerDTO
    {
        public string Name { get; set; }
        public string Pseudonym { get; set; }
        public string PhoneNumber { get; set; }
        public AlbumDTO[] Albums { get; set; }
    }
    public class AlbumDTO
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
    }
}
