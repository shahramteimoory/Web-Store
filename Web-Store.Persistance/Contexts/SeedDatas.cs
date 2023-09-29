using Microsoft.EntityFrameworkCore;
using Web_Store.Common.Roles;
using Web_Store.Domain.Entites.Users;

namespace Web_Store.Persistance.Contexts
{
    public static class SeedDatas
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRole.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRole.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRole.Customer) });

        }
    }
}
