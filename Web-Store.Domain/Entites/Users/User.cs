using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Domain.Entites.Commons;

namespace Web_Store.Domain.Entites.Users
{
    public class User:BaseEntites
    {
        public string FullName { get; set; }
     
        public string Email { get; set; }
      
        public string Password { get; set; }
      
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
