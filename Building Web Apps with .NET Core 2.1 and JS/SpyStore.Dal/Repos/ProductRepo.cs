using Microsoft.EntityFrameworkCore;
using SpyStore.Dal.EfStructures;
using SpyStore.Dal.Repos.Base;
using SpyStore.Dal.Repos.Interfaces;
using SpyStore.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SpyStore.Dal.Repos
{
    public class ProductRepo : RepoBase<Product>, IProductRepo
    {
        public override IEnumerable<Product> GetAll()
        {
            return base.GetAll(x => x.Details.ModelName);
        }

        public ProductRepo(StoreContext context) : base(context)
        {
        }
        internal ProductRepo(DbContextOptions<StoreContext> options)
        : base(options)
        {
        }

        public IList<Product> GetProductsForCategory(int id)
        {
            return Table.Where(p => p.CategoryId == id)
            .Include(p => p.CategoryNavigation)
            .OrderBy(x => x.Details.ModelName)
            .ToList();
        }

        public IList<Product> GetFeaturedWithCategoryName()
        {
            return Table.Where(p => p.IsFeatured)
            .Include(p => p.CategoryNavigation)
            .OrderBy(x => x.Details.ModelName)
            .ToList();
        }

        public Product GetOneWithCategoryName(int id)
        {
            return Table.Where(p => p.Id == id)
                    .Include(p => p.CategoryNavigation)
                    .FirstOrDefault();
        }

        public IList<Product> Search(string searchString)
        {
            return Table.Where(p => EF.Functions.Like(p.Details.Description, $"%{searchString}%") || EF.Functions.Like(p.Details.ModelName, $"%{searchString}%"))
                .Include(p => p.CategoryNavigation)
                .OrderBy(x => x.Details.ModelName)
                .ToList();
        }
    }
}
