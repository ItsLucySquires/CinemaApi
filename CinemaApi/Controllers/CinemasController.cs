using CinemaApi.Data.Handlers;
using CinemaApi.Data.Handlers.Cinema;
using CinemaApi.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
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

    
    /// <summary>
    /// Updates an existing cinema with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the cinema to update.</param>
    /// <param name="cinema">The updated cinema data.</param>
    /// <returns>An IActionResult indicating the result of the operation.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCinema(System.Guid? id, Cinema cinema)
    {
        if (id != cinema.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(new UpdateCinemaCommand(id, cinema));

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
        var cinema = new Cinema()
        {
            Id = Guid.NewGuid(),
            Address = address,
            Name = name,
        };

        await _mediator.Send(new PostCinemaCommand(cinema));

        return CreatedAtAction("GetCinema", new { id = cinema.Id }, cinema);
    }

    // DELETE: api/Cinema/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCinema(System.Guid id)
    {
        await _mediator.Send(new DeleteCinemaCommand(id));
        return Ok();
    }
}
