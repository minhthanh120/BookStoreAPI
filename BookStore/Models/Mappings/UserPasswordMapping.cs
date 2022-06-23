using BookStore.Models.Entities;
using NHibernate.Mapping.ByCode.Conformist;
namespace BookStore.Models.Mappings
{
    public class UserPasswordMapping : ClassMapping<UserPassword>
    {
        public UserPasswordMapping()
        {
            Table("UserPassword");
            Id<string>(x => x.Account);
            Property<string>(x => x.Salt);
            Property<string>(x => x.Hash_MD5);
        }
    }
}
