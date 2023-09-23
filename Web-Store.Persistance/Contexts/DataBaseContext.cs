using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
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


    }
}
