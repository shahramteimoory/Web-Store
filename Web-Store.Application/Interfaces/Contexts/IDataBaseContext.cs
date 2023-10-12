using Microsoft.EntityFrameworkCore;
using Web_Store.Domain.Entites.Carts;
using Web_Store.Domain.Entites.Finances;
using Web_Store.Domain.Entites.HomePage;
using Web_Store.Domain.Entites.Orders;
using Web_Store.Domain.Entites.Products;
using Web_Store.Domain.Entites.Users;

namespace Web_Store.Application.Interfaces.Contexts
{
    /// <summary>
    /// اینترفیس کانتکست
    /// </summary>
    public interface IDataBaseContext
    {
        DbSet<User> users { get; set; }
        DbSet<Role> roles { get; set; }
        DbSet<UserInRole> UserInRoles { get; set; }
        DbSet<Category> categories { get; set; }
        DbSet<Product> products { get; set; }
        DbSet<ProductFeatures> ProductFeatures { get; set; }
        DbSet<ProductImages> productImages { get; set; }
        DbSet<Slider> sliders { get; set; }
        DbSet<HomePageImages> HomePageImages { get; set; }
        DbSet<Cart> carts { get; set; }
        DbSet<CartItems> cartItems { get; set; }
        DbSet<RequestPay> requestPays { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
