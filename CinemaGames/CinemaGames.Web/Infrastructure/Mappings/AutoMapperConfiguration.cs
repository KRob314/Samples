using AutoMapper;
using CinemaGames.Web.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaGames.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
            });
        }
    }
}