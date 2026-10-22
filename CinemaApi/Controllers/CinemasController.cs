using CinemaApi.Data.Handlers;
using CinemaApi.Data.Handlers.Cinema;
using CinemaApi.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CinemasController : ControllerBase
{
    private readonly IMediator _mediator;
    public CinemasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Returns a list of all Cinemas
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cinema>>> GetCinemas()
    {
        var result = await _mediator.Send(new CinemaQuery());
        return Ok(result);
    }

    /// <summary>
    /// Returns a list of cinemas that match specified search criteria
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Cinema>> GetCinema(System.Guid id)
    {
        var result = await _mediator.Send(new CinemaQuery());

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
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
