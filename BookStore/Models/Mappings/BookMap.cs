using BookStore.Models.Entities;
using FluentNHibernate.Mapping;
namespace BookStore.Models.Mappings
{
    public class BookMap:ClassMap<Book>
    {
        public BookMap()
        {
            Table("Book");
            Id(x=>x.BookId, "BookId").GeneratedBy.Identity();
            Map(x=>x.BookName, "BookName");
            Map(x => x.Price, "Price");
            Map(x => x.BookDescr, "BookDescr");
            Map(x => x.Supplier, "Supplier");
            Map(x => x.Publisher, "Publisher");
            Map(x => x.Weight, "Weight");
            Map(x => x.Height, "Height");
            Map(x => x.Length, "Length");
            Map(x => x.Width, "Width");
            Map(x => x.PublishYear, "PublishYear");
            HasManyToMany(x => x.Authors).Cascade.SaveUpdate().Table("AuthorBook")
                .LazyLoad()
                .ParentKeyColumn("BookId")
                .ChildKeyColumn("AuthorId");
            HasManyToMany(x => x.Categories).Cascade.SaveUpdate().Table("CategoryBook")
                .LazyLoad()
                .ParentKeyColumn("BookId")
                .ChildKeyColumn("CategoryId");
            HasMany(x => x.Pictures).KeyColumn("BookID");
            HasMany(x => x.Evals).KeyColumn("BookID");

        }
    }
}
