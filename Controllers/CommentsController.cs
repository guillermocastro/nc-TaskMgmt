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
  public class CommentsController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public CommentsController(ApplicationDbContext context)
    {
      _context = context;
    }
    // GET: api/Comment
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
    {
      return await _context.Comment.ToListAsync();
    }

    // GET: api/Comment/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetComment(int id)
    {
      var Comment = await _context.Comment.FindAsync(id);

      if (Comment == null)
      {
        return NotFound();
      }

      return Comment;
    }
    // POST: api/Comment
    [HttpPost]
    public async Task<ActionResult<Comment>> PostComment(Comment item)
    {
      _context.Comment.Add(item);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetComments), new { id = item.CommentId }, item);
    }
    // PUT: api/Comment/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutComment(int id, Comment item)
    {
      if (id != item.CommentId)
      {
        return BadRequest();
      }

      _context.Entry(item).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }
    // DELETE: api/Comment/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
      var Comment = await _context.Comment.FindAsync(id);

      if (Comment == null)
      {
        return NotFound();
      }

      _context.Comment.Remove(Comment);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}