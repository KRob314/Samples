using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Entities
{
    public class Match : IEntityBase
    {
        public int Id { get; set; }
        public Nullable<int> SeasonId { get; set; }
        public Nullable<int> GenreId { get; set; }
        public int StatusId { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public bool IsCurrent { get; set; }
        public string FullName { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Season Season { get; set; }
        public virtual Status Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieSubmission> MovieSubmissions { get; set; }

        public Match()
        {
            this.MovieSubmissions = new HashSet<MovieSubmission>();
        }
    }
}
