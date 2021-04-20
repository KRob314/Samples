using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaGames.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        CinemaGamesContext dbContext;

        public CinemaGamesContext Init()
        {
            return dbContext ?? (dbContext = new CinemaGamesContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
