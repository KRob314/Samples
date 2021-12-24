using CinemaGames.Data.Repositories;
using CinemaGames.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using System.Web.Http;
using CinemaGames.Web.Infrastructure.Extensions;
using System.Net.Http;
using CinemaGames.Entities;

namespace CinemaGames.Web.Infrastructure.Core
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        public IEntityBaseRepository<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IEntityBase, new()
        {
            return request.GetDataRepository<T>();
        }
    }

    public interface IDataRepositoryFactory
    {
        IEntityBaseRepository<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IEntityBase, new();
    }
}