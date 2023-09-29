using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Domain.Entites.Commons;

namespace Web_Store.Domain.Entites.Products
{
    public class Category:BaseEntites
    {
        public string Name { get; set; }

        public virtual Category ParentCategory { get; set; }
        public long? ParentCategoryId { get; set; }


        public virtual ICollection<Category> SubCategories { get; set; }
    }
}
