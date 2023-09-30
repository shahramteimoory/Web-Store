using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed kardan etelat be data base
            SeedDatas.SeedData(modelBuilder);
            //نمیزاره ایمیل تکراری ثبت بشه
            modelBuilder.Entity<User>().HasIndex(u=>u.Email).IsUnique();

            //کوری فیلتر که تکراری ها رو لود نکنه پ
            QueryFiltters.QueryFiltter(modelBuilder);
        }
    }
}
