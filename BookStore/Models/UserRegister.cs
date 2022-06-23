namespace BookStore.Models
{
    public class UserRegister
    {
        public virtual string Account { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
    }
}
