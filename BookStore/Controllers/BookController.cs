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
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            List<Book> books = new List<Book>();
            using (ISession session = NhibernateSession.OpenSession())  // Open a session to conect to the database
            {
                books = (List<Book>)session.CreateCriteria<Book>().List<Book>();
            }
            // Open a session to conect to the database
            return books;
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            Book book = new Book();
            using (ISession session = NhibernateSession.OpenSession())  // Open a session to conect to the database
            {
                book = session.Get<Book>(id);
            }
            return book;

        }

        // POST api/<BookController>
        [HttpPost]
        public Book Post([FromBody] Book book)
        {
            Book newBook = new Book();
            using (ISession session = NhibernateSession.OpenSession())  // Open a session to conect to the database
            {
                using (var tx = session.BeginTransaction())
                {
                    session.CreateSQLQuery("SET IDENTITY_INSERT dbo.Book ON").UniqueResult();
                    session.Save(book);
                    tx.Commit();
                    session.CreateSQLQuery("SET IDENTITY_INSERT dbo.Book OFF").UniqueResult();
                    newBook = book;
                }
            }
            return newBook;
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            using (ISession session = NhibernateSession.OpenSession())  // Open a session to conect to the database
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Update(book);
                    tx.Commit();
                }
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, [FromBody] Book book)
        {
            using (ISession session = NhibernateSession.OpenSession())  // Open a session to conect to the database
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Delete(book);
                    tx.Commit();
                }
            }
        }
    }
}
