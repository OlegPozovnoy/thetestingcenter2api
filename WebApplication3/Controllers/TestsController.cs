using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    public class TestsController : Controller
    {

        DbModel db;

        public TestsController(DbModel db) {
            this.db = db;
        }
        
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Test> Get()
        {
            return db.Tests.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var test = db.Tests.SingleOrDefault(p => p.Id == id);

            if (test == null)
            {
                return NotFound();
            }
            else
                return Ok(test);
            
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else {
                db.Tests.Add(test);
                db.SaveChanges();
                return CreatedAtAction("Post", new { id = test.Id}, test);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", new { id = test.Id }, test);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var test = db.Tests.SingleOrDefault(p => p.Id == id);

            if (test == null)
            {
                return NotFound();
            }
            else
            {
                db.Tests.Remove(test);
                return Ok();
            }
        }
    }
}
