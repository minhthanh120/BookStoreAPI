using BookStore.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.Interfaces;
using BookStore.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IData<Category> _db;
        public CategoryController( IData<Category> db)
        {
            _db = db;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get(string ?search = "", int pagedNum = 1, int pagedSize = 10)
        { 
            var result = _db.GetAll(search.Trim().ToLower(), pagedNum, pagedSize);
            if (result == null)
                return BadRequest("Empty result");
            return Ok(result);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _db.GetById(id);
            if (result == null)
                return BadRequest("Dont have this category");
            return Ok(new { result });
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Category obj)
        {
            Category category = _db.Create(obj);
            if (category == null)
                return BadRequest("Error Create Category");
            return Ok(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category obj)
        {
            obj.CategoryId = id;
            Category category = _db.Update(obj);
            if (category == null)
                return BadRequest("Error Update Category");
            return Ok(category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
