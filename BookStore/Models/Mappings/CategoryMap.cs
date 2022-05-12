using BookStore.Models.Entities;
using FluentNHibernate.Mapping;
namespace BookStore.Models.Mappings
{
    public class CategoryMap:ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Category");
            Id(x => x.CategoryId, "CategoryId").GeneratedBy.Identity();
            Map(x => x.CategoryName, "CategoryName");
            HasManyToMany(x=>x.Books).Cascade.SaveUpdate().Table("CategoryBook")
                .LazyLoad()
                .ParentKeyColumn("CategoryId")
                .ChildKeyColumn("BookId");
        }
    }
}
