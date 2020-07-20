using LecyShop.Data.Infrastructure;
using LecyShop.Model.Models;

namespace LecyShop.Data.Repositories
{
    /// <summary>
    /// Khai báo các method riêng của Product
    /// </summary>
    public interface IProductRepository
    {

    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        /// <summary>
        /// Hàm tạo Product
        /// </summary>
        /// <param name="dbFactory"></param>
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}