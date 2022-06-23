using BookStore.Models.Entities;
using NHibernate.Mapping.ByCode.Conformist;

namespace BookStore.Models.Mappings
{
    public class UserMapping:ClassMapping<User>
    {
        public UserMapping()
        {
            Id<string>(x => x.Account);
            Property<string>(x=>x.Email);
            Property<string>(x => x.Firstname);
            Property<string>(x => x.Lastname);
            Property<string>(x => x.Avatar);
        }
    }
}
