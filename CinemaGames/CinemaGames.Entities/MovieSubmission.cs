using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Entities
{
    public class MovieSubmission : IEntityBase 
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int MatchId { get; set; }
        public string Title { get; set; }
        public string Trailer { get; set; }
        public System.DateTime SubmissionDate { get; set; }
        public string ReasonToChoose { get; set; }
        public string Synopsis { get; set; }

        public virtual Match Match { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieRating> MovieRatings { get; set; }
        public virtual Player Player { get; set; }

        public MovieSubmission()
        {
            this.MovieRatings = new HashSet<MovieRating>();
        }

    }
}
