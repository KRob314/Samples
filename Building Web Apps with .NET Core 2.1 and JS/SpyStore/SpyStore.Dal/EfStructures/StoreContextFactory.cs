using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SpyStore.Dal.EfStructures
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            var connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SpyStore21;Integrated Security=True;MultipleActiveResultSets=true;";

            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            optionsBuilder.ConfigureWarnings(warnings => 
                warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));

            Console.WriteLine(connectionString);

            return new StoreContext(optionsBuilder.Options);
        }
    }
}
