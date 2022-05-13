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
    public class AuthorController : ControllerBase
    {
        IData<Author> db;
        public AuthorController()
        {
            db = new AuthorDAL();
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public IList<Author> Get()
        {
            return db.GetAll();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return db.GetById(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public Author Post([FromBody] Author author)
        {
            return db.Create(author);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public Author Put(int id, [FromBody] Author author)
        {
            return db.Update(author);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return db.Delete(db.GetById(id));
        }
    }
}
