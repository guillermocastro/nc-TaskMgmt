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
  public class ProgresssController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public ProgresssController(ApplicationDbContext context)
    {
      _context = context;
    }
    // GET: api/Progress
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Progress>>> GetProgresss()
    {
      return await _context.Progress.ToListAsync();
    }

    // GET: api/Progress/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Progress>> GetProgress(int id)
    {
      var Progress = await _context.Progress.FindAsync(id);

      if (Progress == null)
      {
        return NotFound();
      }

      return Progress;
    }
    // POST: api/Progress
    [HttpPost]
    public async Task<ActionResult<Progress>> PostProgress(Progress item)
    {
      _context.Progress.Add(item);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetProgresss), new { id = item.ProgressId }, item);
    }
    // PUT: api/Progress/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProgress(int id, Progress item)
    {
      if (id != item.ProgressId)
      {
        return BadRequest();
      }

      _context.Entry(item).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }
    // DELETE: api/Progress/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProgress(int id)
    {
      var Progress = await _context.Progress.FindAsync(id);

      if (Progress == null)
      {
        return NotFound();
      }

      _context.Progress.Remove(Progress);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}