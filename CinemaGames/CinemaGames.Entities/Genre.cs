using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Entities
{
    public class Genre : IEntityBase
    {
        public Genre()
        {
          
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
