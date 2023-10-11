    using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Domain.Entites.Carts;
using Web_Store.Domain.Entites.Finances;
using Web_Store.Domain.Entites.HomePage;
using Web_Store.Domain.Entites.Orders;
using Web_Store.Domain.Entites.Products;
using Web_Store.Domain.Entites.Users;

namespace Web_Store.Persistance.Contexts
{
    /// <summary>
    /// کانتکست
    /// </summary>
    public class DataBaseContext:DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) :base (options)
        {
            
        }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Category> categories {  get; set; }
        public DbSet<Product> products { get; set;}
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<ProductImages> productImages { get; set; }
        public DbSet<Slider> sliders {  get; set; }
        public DbSet<HomePageImages> HomePageImages { get; set; }
        public DbSet<Cart> carts {  get; set; }
        public DbSet<CartItems> cartItems {  get; set; }
        public DbSet<RequestPay> requestPays {get; set;}
        public DbSet<Order> order { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(o=>o.User)
                .WithMany(o=>o.orders).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>().HasOne(o => o.RequestPay)
     .WithMany(o => o.orders).OnDelete(DeleteBehavior.NoAction);


            //seed kardan etelat be data base
            SeedDatas.SeedData(modelBuilder);
            //نمیزاره ایمیل تکراری ثبت بشه
            modelBuilder.Entity<User>().HasIndex(u=>u.Email).IsUnique();

            //کوری فیلتر که تکراری ها رو لود نکنه پ
            QueryFiltters.QueryFiltter(modelBuilder);
        }
    }
}
