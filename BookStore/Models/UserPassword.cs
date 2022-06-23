namespace BookStore.Models
{
    public class UserPassword
    {
        public virtual string Account { get; set; }
        public virtual string Password { get; set; }
        public virtual string Salt { get; set; }
        public virtual string Hash_MD5 { get; set; }
    }
}
