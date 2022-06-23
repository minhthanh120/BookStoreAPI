using BookStore.Models.Entities;
using NHibernate.Mapping.ByCode.Conformist;
namespace BookStore.Models.Mappings
{
    public class CategoryMap : ClassMapping<Category>
    {
        public CategoryMap()
        {
            Table("Category");
            Id(x => x.CategoryId, m => m.Column("CategoryId"));
            Property(x => x.CategoryName, m => m.Column("CategoryName"));
            Bag(x => x.Books,
                c =>
                {
                    c.Cascade(NHibernate.Mapping.ByCode.Cascade.All);
                },
                r => r.OneToMany());
        }
    }
}
