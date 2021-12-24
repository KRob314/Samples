using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Entities
{
    public class UserRole : IEntityBase
    {
        public int Id { get; set; }
        //[ForeignKey("UserId")]
        public int UserId { get; set; }
        //[ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
