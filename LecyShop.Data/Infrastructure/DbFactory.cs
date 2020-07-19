using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecyShop.Data.Infrastructure
{
   public class DbFactory : Disposable, IDbFactory
    {
        private LecyShopDbContext dbContext;

        public LecyShopDbContext Init()
        {
            // Nếu dbContext null thì tạo mới 
            return dbContext ?? (dbContext = new LecyShopDbContext());
        }

        protected override void DisposeCore()
        {
            //Nếu khác null thì vứt bỏ nó 
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
