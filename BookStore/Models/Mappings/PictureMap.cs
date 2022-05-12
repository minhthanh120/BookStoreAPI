using BookStore.Models.Entities;
using FluentNHibernate.Mapping;
namespace BookStore.Models.Mappings
{
    public class PictureMap:ClassMap<Picture>
    {
        public PictureMap()
        {
            Table("Picture");
            Id(x => x.PictureId, "PictureId").GeneratedBy.Identity();
            Map(x=>x.PicturePath, "PicturePath");
            References(x => x.Book,"BookId");
        }
    }
}
