using BookStore.Models.Entities;
using FluentNHibernate.Mapping;
namespace BookStore.Models.Mappings
{
    public class CategoryMap:ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.CategoryId);
            Map(x => x.CategoryId);
            HasManyToMany(x=>x.Books).Cascade.All().Table("CategoryBook");
        }
    }
}
