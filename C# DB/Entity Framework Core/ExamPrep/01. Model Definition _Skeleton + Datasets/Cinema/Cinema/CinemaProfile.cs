using AutoMapper;
using Cinema.Data.Models;
using Cinema.Data.Models.Enums;
using Cinema.DataProcessor.ImportDto;
using System;
using System.Collections.Generic;

namespace Cinema
{
    public class CinemaProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public CinemaProfile()
        {
            CreateMap<MovieDTO, Movie>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.Genre, o => o.MapFrom(s => Enum.Parse(typeof(Genre), s.Genre)))
                .ForMember(d => d.Duration, o => o.MapFrom(s => s.Duration))
                .ForMember(d => d.Rating, o => o.MapFrom(s => s.Rating))
                .ForMember(d => d.Director, o => o.MapFrom(s => s.Director));
            CreateMap<HallDTO, Hall>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Is3D, o => o.MapFrom(s => s.Is3D))
                .ForMember(d => d.Is4Dx, o => o.MapFrom(s => s.Is4Dx));
        }
    }
}
