using apitest.Data;
using apitest.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apitest.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase {
        private readonly ILogger<ClassController> _logger;
        private readonly SchoolDbContext _context;

        public ClassController(ILogger<ClassController> logger, SchoolDbContext context) {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() {
            _logger.LogInformation("Getting all classes");
            return Ok(_context.Classrooms.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            _logger.LogInformation("Getting class with id {id}", id);
            var classroom = _context.Classrooms.Find(id);
            if (classroom == null) {
                return NotFound();
            }
            return Ok(classroom);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Classroom classroom) {
            _logger.LogInformation("Creating new class");
            _context.Classrooms.Add(classroom);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = classroom.Id }, classroom);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Classroom classroom) {
            _logger.LogInformation("Updating class with id {id}", id);
            if (id != classroom.Id) {
                return BadRequest();
            }
            _context.Entry(classroom).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _logger.LogInformation("Deleting class with id {id}", id);
            var classroom = _context.Classrooms.Find(id);
            if (classroom == null) {
                return NotFound();
            }
            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
