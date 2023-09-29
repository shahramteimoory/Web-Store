using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Store.Domain.Entites.Products
{
    public class Category
    {
        public string Name { get; set; }

        public virtual Category ParentCategory { get; set; }
        public long? ParentCategoryId { get; set; }


        public virtual ICollection<Category> SubCategories { get; set; }
    }
}
