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
  public class LinksController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public LinksController(ApplicationDbContext context)
    {
      _context = context;
    }
    // GET: api/Link
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Link>>> GetLinks()
    {
      return await _context.Link.ToListAsync();
    }

    // GET: api/Link/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Link>> GetLink(int id)
    {
      var Link = await _context.Link.FindAsync(id);

      if (Link == null)
      {
        return NotFound();
      }

      return Link;
    }
    // POST: api/Link
    [HttpPost]
    public async Task<ActionResult<Link>> PostLink(Link item)
    {
      _context.Link.Add(item);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetLinks), new { id = item.LinkId }, item);
    }
    // PUT: api/Link/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLink(int id, Link item)
    {
      if (id != item.LinkId)
      {
        return BadRequest();
      }

      _context.Entry(item).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }
    // DELETE: api/Link/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLink(int id)
    {
      var Link = await _context.Link.FindAsync(id);

      if (Link == null)
      {
        return NotFound();
      }

      _context.Link.Remove(Link);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}