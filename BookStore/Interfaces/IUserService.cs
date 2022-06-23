using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IUserService
    {
        Task<bool> Login(UserLogin user);
        Task<bool> Register(UserRegister user);
    }
}
