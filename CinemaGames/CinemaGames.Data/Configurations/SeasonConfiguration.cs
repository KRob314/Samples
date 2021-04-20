using CinemaGames.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Data.Configurations
{
    public class SeasonConfiguration : EntityBaseConfiguration<Season>
    {
        public SeasonConfiguration()
        {
            Property(s => s.Id).IsRequired();
            Property(s => s.Name).IsRequired().HasMaxLength(150);
            //HasMany(s => s.Matches).WithRequired().HasForeignKey(m => m.Id);
        }
    }
}
