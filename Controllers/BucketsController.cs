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
  public class BucketsController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public BucketsController(ApplicationDbContext context)
    {
      _context = context;
    }
    // GET: api/Bucket
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bucket>>> GetBuckets()
    {
      return await _context.Bucket.ToListAsync();
    }

    // GET: api/Bucket/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Bucket>> GetBucket(int id)
    {
      var Bucket = await _context.Bucket.FindAsync(id);

      if (Bucket == null)
      {
        return NotFound();
      }

      return Bucket;
    }
    // POST: api/Bucket
    [HttpPost]
    public async Task<ActionResult<Bucket>> PostBucket(Bucket item)
    {
      _context.Bucket.Add(item);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetBuckets), new { id = item.BucketId }, item);
    }
    // PUT: api/Bucket/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBucket(int id, Bucket item)
    {
      if (id != item.BucketId)
      {
        return BadRequest();
      }

      _context.Entry(item).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }
    // DELETE: api/Bucket/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBucket(int id)
    {
      var Bucket = await _context.Bucket.FindAsync(id);

      if (Bucket == null)
      {
        return NotFound();
      }

      _context.Bucket.Remove(Bucket);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}