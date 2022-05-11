using BookStore.Models.Entities;
using FluentNHibernate.Mapping;
namespace BookStore.Models.Mappings
{
    public class PictureMap:ClassMap<Picture>
    {
        public PictureMap()
        {
            Id(x => x.PictureId);
            Map(x=>x.PicturePath);
            References(x => x.Book);
        }
    }
}
