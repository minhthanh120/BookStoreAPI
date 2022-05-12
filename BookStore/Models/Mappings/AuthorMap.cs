using BookStore.Models.Entities;
using FluentNHibernate.Mapping;

namespace BookStore.Models.Mappings
{
    public class AuthorMap:ClassMap<Author>
    {
        public AuthorMap()
        {
            Table("Author");
            Id(x => x.AuthorId, "AuthorId").GeneratedBy.Identity();
            Map(x=>x.AuthorName, "AuthorName");
            Map(x=>x.AuthorDescr, "AuthorDescr");
            HasManyToMany(x=>x.Books).Cascade.SaveUpdate().Table("AuthorBook")
                .LazyLoad()
                .ParentKeyColumn("AuthorId")
                .ChildKeyColumn("BookId");
        }
    }
}
