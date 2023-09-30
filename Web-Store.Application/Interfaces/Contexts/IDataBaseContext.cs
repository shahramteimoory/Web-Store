using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        DbSet<ProductFeatures>ProductFeatures { get; set; }
        DbSet<ProductImages>productImages { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess , CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
