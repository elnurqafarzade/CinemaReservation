using CinemaApp.Core.Entities;
using CinemaApp.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimesController : ControllerBase
    {
            private readonly AppDBContext _context;

            public ShowTimesController(AppDBContext context)
            {
                _context = context;
            }

           
            [HttpGet]
            public async Task<ActionResult<IEnumerable<ShowTime>>> GetShowtimes()
            {
                return await _context.Showtimes
                                     .Include(s => s.Movie)    
                                     .Include(s => s.Theater)  
                                     .ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<ShowTime>> GetShowtime(int id)
            {
                var showtime = await _context.Showtimes
                                             .Include(s => s.Movie)
                                             .Include(s => s.Theater)
                                             .FirstOrDefaultAsync(s => s.Id == id);

                if (showtime == null)
                {
                    return NotFound();
                }

                return showtime;
            }

            [HttpPost]
            public async Task<ActionResult<ShowTime>> CreateShowtime(ShowTime showtime)
            {
                _context.Showtimes.Add(showtime);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetShowtime), new { id = showtime.Id }, showtime);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateShowtime(int id, ShowTime showtime)
            {
                if (id != showtime.Id)
                {
                    return BadRequest();
                }

                _context.Entry(showtime).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowtimeExists(id))
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
            public async Task<IActionResult> DeleteShowtime(int id)
            {
                var showtime = await _context.Showtimes.FindAsync(id);
                if (showtime == null)
                {
                    return NotFound();
                }

                _context.Showtimes.Remove(showtime);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            [HttpGet("{id}/seatreservations")]
            public async Task<ActionResult<IEnumerable<SeatReservation>>> GetSeatReservationsByShowtime(int id)
            {
                var showtime = await _context.Showtimes
                                            
                                             .FirstOrDefaultAsync(s => s.Id == id);

                if (showtime == null)
                {
                    return NotFound();
                }

                return Ok(showtime.Reservations);
            }

            private bool ShowtimeExists(int id)
            {
                return _context.Showtimes.Any(e => e.Id == id);
            }
    }
}

