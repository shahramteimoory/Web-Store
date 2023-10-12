using Web_Store.Domain.Entites.Commons;

namespace Web_Store.Domain.Entites.Products
{
    public class Category : BaseEntites
    {
        public string Name { get; set; }

        public virtual Category ParentCategory { get; set; }
        public long? ParentCategoryId { get; set; }


        public virtual ICollection<Category> SubCategories { get; set; }
    }
}
