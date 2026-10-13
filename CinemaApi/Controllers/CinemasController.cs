using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaApi.Models;

[Route("api/[controller]")]
[ApiController]
public class CinemasController : ControllerBase
{
    private readonly CinemaApiContext _context;
    public CinemasController(CinemaApiContext context)
    {
        _context = context;
    }

    // GET: api/Cinema
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cinema>>> GetCinema()
    {
        return await _context.Cinema.ToListAsync();
    }

    // GET: api/Cinema/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Cinema>> GetCinema(System.Guid id)
    {
        var cinema = await _context.Cinema.FindAsync(id);

        if (cinema == null)
        {
            return NotFound();
        }

        return cinema;
    }

    // PUT: api/Cinema/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCinema(System.Guid? id, Cinema cinema)
    {
        if (id != cinema.Id)
        {
            return BadRequest();
        }

        _context.Entry(cinema).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CinemaExists(id))
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

    /// <summary>
    /// Creates a new cinema with the specified address and name.
    /// </summary>
    /// <param name="address">Full address of the cinema</param>
    /// <param name="name">Cinema name</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Cinema>> PostCinema(string address, string name)
    {
        Cinema cinema = new Cinema()
        {
            Id = Guid.NewGuid(),
            Address = address, 
            Name = name, 
        };
        _context.Cinema.Add(cinema);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCinema", new { id = cinema.Id }, cinema);
    }

    // DELETE: api/Cinema/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCinema(System.Guid? id)
    {
        var cinema = await _context.Cinema.FindAsync(id);
        if (cinema == null)
        {
            return NotFound();
        }

        _context.Cinema.Remove(cinema);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CinemaExists(System.Guid? id)
    {
        return _context.Cinema.Any(e => e.Id == id);
    }
}
