using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaApi.Models;

[Route("api/[controller]")]
[ApiController]
public class ShowingsController : ControllerBase
{
    private readonly CinemaApiContext _context;
    public ShowingsController(CinemaApiContext context)
    {
        _context = context;
    }

    // GET: api/Showing
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Showing>>> GetShowing()
    {
        return await _context.Showing.ToListAsync();
    }

    // GET: api/Showing/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Showing>> GetShowing(System.Guid id)
    {
        var showing = await _context.Showing.FindAsync(id);

        if (showing == null)
        {
            return NotFound();
        }

        return showing;
    }

    // PUT: api/Showing/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutShowing(System.Guid? id, Showing showing)
    {
        if (id != showing.Id)
        {
            return BadRequest();
        }

        _context.Entry(showing).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ShowingExists(id))
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

    // POST: api/Showing
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Showing>> PostShowing(Showing showing)
    {
        _context.Showing.Add(showing);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetShowing", new { id = showing.Id }, showing);
    }

    // DELETE: api/Showing/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShowing(System.Guid? id)
    {
        var showing = await _context.Showing.FindAsync(id);
        if (showing == null)
        {
            return NotFound();
        }

        _context.Showing.Remove(showing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ShowingExists(System.Guid? id)
    {
        return _context.Showing.Any(e => e.Id == id);
    }
}
