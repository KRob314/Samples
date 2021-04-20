using CinemaGames.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Data.Configurations
{
    public class MovieSubmissionConfiguration: EntityBaseConfiguration<MovieSubmission>
    {
        public MovieSubmissionConfiguration()
        {
            Property(ms => ms.Id).IsRequired();
            Property(ms => ms.PlayerId).IsRequired();
            Property(ms => ms.MatchId).IsRequired();
            Property(ms => ms.Title).IsRequired().HasMaxLength(250);
            Property(ms => ms.Trailer).IsRequired().HasMaxLength(500);
            Property(ms => ms.ReasonToChoose).IsRequired().HasMaxLength(2000);
            Property(ms => ms.Synopsis).HasMaxLength(2000);
            //HasMany(ms => ms.MovieRatings).WithRequired().HasForeignKey(mr => mr.Id);
        }
    }
}
