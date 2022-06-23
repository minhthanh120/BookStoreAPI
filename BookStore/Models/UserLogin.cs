namespace BookStore.Models
{
    public class UserLogin
    {
        public virtual string Account { get; set; }
        public virtual string Password { get; set; }
        public virtual bool RememberMe { get; set; }
    }
}
