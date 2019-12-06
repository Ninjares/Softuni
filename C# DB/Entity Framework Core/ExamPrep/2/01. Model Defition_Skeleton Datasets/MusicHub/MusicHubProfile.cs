namespace MusicHub
{
    using AutoMapper;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using System;
    using System.Globalization;

    public class MusicHubProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public MusicHubProfile()
        {
            CreateMap<SongDTO, Song>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Duration, o => o.MapFrom(s => TimeSpan.Parse(s.Duration)))
                .ForMember(d => d.CreatedOn, o => o.MapFrom(s => DateTime.ParseExact(s.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(d => d.Genre, o => o.MapFrom(s => (Genre)Enum.Parse(typeof(Genre), s.Genre)))
                .ForMember(d => d.AlbumId, o => o.MapFrom(s => s.AlbumId))
                .ForMember(d => d.WriterId, o => o.MapFrom(s => s.WriterId))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Price));
        }
    }
}
