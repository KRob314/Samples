using CinemaGames.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Data.Configurations
{
    public class MovieRatingConfiguration: EntityBaseConfiguration<MovieRating>
    {
        public MovieRatingConfiguration()
        {
            Property(mr => mr.Id).IsRequired();
            Property(mr => mr.PlayerId).IsRequired();
            Property(mr => mr.MovieSubmissionId).IsRequired();
            Property(mr => mr.Rating).IsRequired();
            Property(mr => mr.ReasonForVote).HasMaxLength(2000);

            
        }
    }
}
