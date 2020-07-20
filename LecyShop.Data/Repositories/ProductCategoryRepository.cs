using System.Collections.Generic;
//LINQ
using System.Linq;
using LecyShop.Data.Infrastructure;
using LecyShop.Model.Models;

namespace LecyShop.Data.Repositories
{
    /// <summary>
    /// Khai báo các phương thức ko có trong RepositoryBase
    /// </summary>
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            //x= ProductCategory
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
} 