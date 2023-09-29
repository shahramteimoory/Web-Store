using Microsoft.EntityFrameworkCore;
using Web_Store.Domain.Entites.Products;
using Web_Store.Domain.Entites.Users;

namespace Web_Store.Persistance.Contexts
{
    public static class QueryFiltters
    {
        public static void QueryFiltter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(ur => !ur.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsRemoved);
        }
    }
}
