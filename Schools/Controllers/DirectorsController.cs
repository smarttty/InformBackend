using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Schools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DirectorsController : ControllerBase
    {
        private readonly SchoolContext _context;
        public DirectorsController(SchoolContext context)
        {
            _context = context;
        }
        // GET: api/<DirectorsController>
        [HttpGet]
        public IEnumerable<Director> Get()
        {
            return _context.Director.ToList();
        }

        // GET api/<DirectorsController>/5
        [HttpGet("{id}")]
        public ActionResult<Director> Get(Guid id)
        {
            var director = _context.Director.Find(id);

            if (director == null)
            {
                return NotFound();
            }

            return director;
        }

        // POST api/<DirectorsController>
        [HttpPost]
        public ActionResult<Director> Post([FromBody] Director director)
        {
            _context.Director.Add(director);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                if (DirectorExists(director.Primarykey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return director;
        }

        // PUT api/<DirectorsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Director director)
        {
            if (id != director.Primarykey)
            {
                return BadRequest();
            }

            _context.Entry(director).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<DirectorsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Director> Delete(Guid id)
        {
            var director = _context.Director.Find(id);
            if (director == null)
            {
                return NotFound();
            }

            _context.Director.Remove(director);
            _context.SaveChanges();

            return director;
        }

        private bool DirectorExists(Guid id)
        {
            return _context.Director.Any(e => e.Primarykey == id);
        }
    }
}
