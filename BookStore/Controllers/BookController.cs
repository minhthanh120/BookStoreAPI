using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using ISession = NHibernate.ISession;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IData<Book> db;
        public BookController()
        {
            db = new BookDAL();
        }
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            // Open a session to conect to the database
            return db.GetAll();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return db.GetById(id);

        }

        // POST api/<BookController>
        [HttpPost]
        public Book Post([FromBody] Book book)
        {
            return db.Create(book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public Book Put(int id, [FromBody] Book book)
        {
            return db.Update(book);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id, [FromBody] Book book)
        {
            return db.Delete(book);
        }
    }
}
