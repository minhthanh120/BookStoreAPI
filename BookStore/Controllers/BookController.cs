using BookStore.Interfaces;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IData<Book> _db;
        public BookController(IData<Book> db)
        {
            _db = db;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IActionResult Get(string? search = "", int pagedNum = 1, int pagedSize = 10)
        {
            // Open a session to conect to the database
            IPaged<Book> paged = _db.GetAll(search.Trim().ToLower(), pagedNum, pagedSize);
            if (paged == null)
                return BadRequest("Empty Result");
            return Ok(paged);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Book result = _db.GetById(id);
            if (result == null)
                return BadRequest("Can't find this Book");
            return Ok(result);
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            Book result = _db.Create(book);
            if (result == null)
                return BadRequest("Can't create book");
            return Ok(result);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            book.BookId = id;
            Book result = _db.Update(book);
            if (result == null)
                return BadRequest("Can't find Book");
            return Ok(result);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Book book = _db.GetById(id);
            if (book == null)
                BadRequest("Can't find this book");
            return Ok(_db.Delete(book));
        }

    }
}
