using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Entities
{
    public class Player : IEntityBase
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieRating> MovieRatings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieSubmission> MovieSubmissions { get; set; }

        public Player()
        {
            this.MovieRatings = new HashSet<MovieRating>();
            this.MovieSubmissions = new HashSet<MovieSubmission>();
        }

    }
}
