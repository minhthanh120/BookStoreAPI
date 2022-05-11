using BookStore.Models.Entities;
using FluentNHibernate.Mapping;

namespace BookStore.Models.Mappings
{
    public class AuthorMap:ClassMap<Author>
    {
        public AuthorMap()
        {
            Id(x => x.AuthorId);
            Map(x=>x.AuthorName);
            Map(x=>x.AuthorDescr);
            HasManyToMany(x=>x.Books).Cascade.All().Table("AuthorBook");
        }
    }
}
