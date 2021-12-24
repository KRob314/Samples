using AutoMapper;
using CinemaGames.Entities;
using CinemaGames.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaGames.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<MovieSubmissionViewModel, MovieSubmission>();
                //.ForMember(m => m.Image, map => map.Ignore())
                //.ForMember(m => m.Genre, map => map.Ignore());
        }
    }
}