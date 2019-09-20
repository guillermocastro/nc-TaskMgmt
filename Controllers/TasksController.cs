using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using js.Data;

namespace js.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TasksController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public TasksController(ApplicationDbContext context)
    {
      _context = context;
    }
    // GET: api/Task
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Task>>> GetTasks()
    {
      return await _context.Task.ToListAsync();
    }

    // GET: api/Task/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Task>> GetTask(int id)
    {
      var Task = await _context.Task.FindAsync(id);

      if (Task == null)
      {
        return NotFound();
      }

      return Task;
    }
    // POST: api/Task
    [HttpPost]
    public async Task<ActionResult<Task>> PostTask(Task item)
    {
      _context.Task.Add(item);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetTasks), new { id = item.TaskId }, item);
    }
    // PUT: api/Task/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTask(int id, Task item)
    {
      if (id != item.TaskId)
      {
        return BadRequest();
      }

      _context.Entry(item).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }
    // DELETE: api/Task/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
      var Task = await _context.Task.FindAsync(id);

      if (Task == null)
      {
        return NotFound();
      }

      _context.Task.Remove(Task);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}