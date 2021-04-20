using CinemaGames.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Data.Configurations
{
    public class PlayerConfiguration: EntityBaseConfiguration<Player>
    {
        public PlayerConfiguration()
        {
            Property(p => p.Id).IsRequired();
            Property(p => p.UserId).IsRequired();
            Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            Property(p => p.LastName).IsRequired().HasMaxLength(100);

        }
    }
}
