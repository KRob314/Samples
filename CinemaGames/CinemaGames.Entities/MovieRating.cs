using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Entities
{
    public class MovieRating : IEntityBase
    {
        public int Id { get; set; }
        //[ForeignKey("PlayerId")]
        public int PlayerId { get; set; }
        //[ForeignKey("MovieSubmissionId")]
        public int MovieSubmissionId { get; set; }
        public int Rating { get; set; }
        public System.DateTime RatingDate { get; set; }
        public string ReasonForVote { get; set; }

        public virtual MovieSubmission MovieSubmission { get; set; }
        public virtual Player Player { get; set; }
    }
}
