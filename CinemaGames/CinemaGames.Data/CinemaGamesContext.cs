using CinemaGames.Data.Configurations;
using CinemaGames.Entities;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Data
{
    public class CinemaGamesContext:  DbContext
    {
        public CinemaGamesContext() : base("CinemaGames")
        {
            Database.SetInitializer<CinemaGamesContext>(null);
        }

        #region Entity Sets
        public IDbSet<User> User { get; set; }
        public IDbSet<Role> Role { get; set; }
        public IDbSet<UserRole> UserRole { get; set; }
        public IDbSet<Player> Player { get; set; }
        public IDbSet<MovieSubmission> MovieSubmission { get; set; }
        public IDbSet<MovieRating> MovieRating { get; set; }
        public IDbSet<Genre> Genre { get; set; }
        public IDbSet<Season> Season { get; set; }
        public IDbSet<Match> Match { get; set; }
        public IDbSet<Error> Error { get; set; }
        public IDbSet<Status> Status { get; set; }
        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new PlayerConfiguration());
            modelBuilder.Configurations.Add(new MovieSubmissionConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new MatchConfiguration());
            modelBuilder.Configurations.Add(new MovieRatingConfiguration());
            modelBuilder.Configurations.Add(new SeasonConfiguration());
        }

    }
}
