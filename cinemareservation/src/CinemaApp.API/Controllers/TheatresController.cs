using CinemaApp.Core.Entities;
using CinemaApp.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatresController : ControllerBase
    {
        
            private readonly AppDBContext _context;

            public TheatresController(AppDBContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Theater>>> GetTheatres()
            {
                return await _context.Theaters
                                     .Include(t => t.ShowTimes) 
                                     .ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Theater>> GetTheatre(int id)
            {
                var theater = await _context.Theaters
                                            .Include(t => t.ShowTimes)
                                            .FirstOrDefaultAsync(t => t.Id == id);

                if (theater == null)
                {
                    return NotFound();
                }

                return theater;
            }

            [HttpPost]
            public async Task<ActionResult<Theater>> CreateTheatre(Theater theater)
            {
                _context.Theaters.Add(theater);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTheatre), new { id = theater.Id }, theater);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateTheatre(int id, Theater theater)
            {
                if (id != theater.Id)
                {
                    return BadRequest();
                }

                _context.Entry(theater).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheatreExists(id))
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

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTheatre(int id)
            {
                var theater = await _context.Theaters.FindAsync(id);
                if (theater == null)
                {
                    return NotFound();
                }

                _context.Theaters.Remove(theater);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            [HttpGet("{id}/showtimes")]
            public async Task<ActionResult<IEnumerable<ShowTime>>> GetShowtimesByTheatre(int id)
            {
                var theater = await _context.Theaters
                                            .Include(t => t.ShowTimes)
                                            .FirstOrDefaultAsync(t => t.Id == id);

                if (theater == null)
                {
                    return NotFound();
                }

                return Ok(theater.ShowTimes);
            }

            private bool TheatreExists(int id)
            {
                return _context.Theaters.Any(e => e.Id == id);
            }
    }
}


