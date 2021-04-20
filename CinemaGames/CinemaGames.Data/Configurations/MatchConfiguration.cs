using CinemaGames.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Data.Configurations
{
    public class MatchConfiguration : EntityBaseConfiguration<Match>
    {
        public MatchConfiguration()
        {
            Property(m => m.Id).IsRequired();
            Property(m => m.GenreId).IsRequired();
            Property(m => m.Name).IsRequired().HasMaxLength(50);
            //HasMany(m => m.MovieSubmissions).WithRequired().HasForeignKey(ms => ms.Id);
        }
    }
}
