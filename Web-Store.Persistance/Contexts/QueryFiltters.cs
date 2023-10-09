using Microsoft.EntityFrameworkCore;
using Web_Store.Domain.Entites.Carts;
using Web_Store.Domain.Entites.HomePage;
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
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductFeatures>().HasQueryFilter(pf => !pf.IsRemoved);
            modelBuilder.Entity<ProductImages>().HasQueryFilter(pi => !pi.IsRemoved);
            modelBuilder.Entity<Slider>().HasQueryFilter(s => !s.IsRemoved);
            modelBuilder.Entity<Cart>().HasQueryFilter(c => !c.IsRemoved);
            modelBuilder.Entity<CartItems>().HasQueryFilter(c => !c.IsRemoved);
        }
    }
}
