using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using ISession = NHibernate.ISession;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IData<Author> _db;
        public AuthorController(IData<Author> db)
        {
            _db = db;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        [ExpectedException(typeof(LazyInitializationException))]
        public IActionResult Get(string? search = "", int pageNum = 1, int pageSize = 10)
        {
            IPaged<Author> result = new IPaged<Author>();
            result = _db.GetAll(search.Trim().ToLower(), pageNum, pageSize);
            if (result == null)
                return BadRequest("Empty result");
            return Ok(result);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Author result = _db.GetById(id);
            if (result != null)
                return Ok(result);
            return BadRequest("Don't have this Author");
        }

        // POST api/<AuthorController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Author author)
        {
            Author result = _db.Create(author);
            if (result == null)
                return BadRequest("Error when Create Author");
            return Ok(_db.Create(author));
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author author)
        {
            author.AuthorId = id;
            Author result = _db.Update(author);
            if (result == null)
                return BadRequest("Dont have this Author");
            return Ok(result);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Author author = _db.GetById(id);
            if (author == null)
                return BadRequest("Dont have this author");
            return Ok(_db.Delete(_db.GetById(id)));
        }
    }
}
