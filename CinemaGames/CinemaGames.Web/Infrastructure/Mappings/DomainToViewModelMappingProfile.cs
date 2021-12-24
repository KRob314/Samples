using AutoMapper;
using CinemaGames.Entities;
using CinemaGames.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaGames.Web.Infrastructure.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<MovieSubmission, MovieSubmissionViewModel>()
                .ForMember(vm => vm.Match, map => map.MapFrom(m => m.Match.FullName))
                .ForMember(vm => vm.MatchId, map => map.MapFrom(m => m.Match.Id));
            //.ForMember(vm => vm.IsAvailable, map => map.MapFrom(m => m.Stocks.Any(s => s.IsAvailable)))
            //.ForMember(vm => vm.NumberOfStocks, map => map.MapFrom(m => m.Stocks.Count))
            //.ForMember(vm => vm.Image, map => map.MapFrom(m => string.IsNullOrEmpty(m.Image) == true ? "unknown.jpg" : m.Image));

            Mapper.CreateMap<Genre, GenreViewModel>();

            Mapper.CreateMap<Match, MatchViewModel>()
                .ForMember(vm => vm.Genre, map => map.MapFrom(m => m.Genre.Name))
                .ForMember(vm => vm.GenreId, map => map.MapFrom(m => m.GenreId))
                .ForMember(vm => vm.Season, map => map.MapFrom(m => m.Season.Name))
                .ForMember(vm => vm.SeasonId, map => map.MapFrom(m => m.SeasonId));


        }
    }
}