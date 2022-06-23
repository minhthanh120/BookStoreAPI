using BookStore.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.Interfaces;
using BookStore.Data;
using BookStore.Models;
using BookStore.Ultilities;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _db;
        public UserController(IUserService db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Login(string account, string password)
        {
            
            return Ok(((UserDAL)_db).Login(new UserLogin { Account=account, Password=password}));
        }
        [Route("Register")]
        [HttpPost]
        public IActionResult Register(UserRegister user)
        {
            return Ok(((UserDAL)_db).Register(user));
        }

    }
}
