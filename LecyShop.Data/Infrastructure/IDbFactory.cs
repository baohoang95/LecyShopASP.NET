using System;

namespace LecyShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        /// <summary>
        /// Khởi tạo DbContext
        /// </summary>
        /// <returns></returns>
        LecyShopDbContext Init();
    }
}