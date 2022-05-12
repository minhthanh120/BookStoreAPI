using BookStore.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using ISession = NHibernate.ISession;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        // GET: api/<AuthorController>
        [HttpGet]
        public IList<Author> Get()
        {
            List<Author> authors = new List<Author>();
            using(var session = NhibernateSession.OpenSession())
            {
                authors = (List<Author>)session.CreateCriteria<Author>().List<Author>();
            }
            
            //NhibernateSession.CloseSession();
            // Open a session to conect to the database
            return authors;
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            Author author = new Author();
            // Open a session to conect to the database
            using(var session = NhibernateSession.OpenSession())
            {
                author = session.QueryOver<Author>()
                  .Fetch(u => u.Books)
                  .Eager
                  .List()
                  .Where(u => u.AuthorId == id)
                  .FirstOrDefault();
            }
            ;  // Open a session to conect to the database
            
            //NhibernateSession.CloseSession();
            return author;
        }

        // POST api/<AuthorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
