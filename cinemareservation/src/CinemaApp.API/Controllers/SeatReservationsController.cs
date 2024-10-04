using CinemaApp.Core.Entities;
using CinemaApp.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatReservationsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public SeatReservationsController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatReservation>>> GetSeatReservations()
        {
            return await _context.SeatReservations
                                 .Include(sr => sr.ShowTime)   
                                 .Include(sr => sr.User)       
                                 .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeatReservation>> GetSeatReservation(int id)
        {
            var seatReservation = await _context.SeatReservations
                                                .Include(sr => sr.ShowTime)
                                                .Include(sr => sr.User)
                                                .FirstOrDefaultAsync(sr => sr.Id == id);

            if (seatReservation == null)
            {
                return NotFound();
            }

            return seatReservation;
        }


        [HttpPost]
        public async Task<ActionResult<SeatReservation>> CreateSeatReservation(SeatReservation seatReservation)
        {
            _context.SeatReservations.Add(seatReservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeatReservation), new { id = seatReservation.Id }, seatReservation);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeatReservation(int id, SeatReservation seatReservation)
        {
            if (id != seatReservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(seatReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatReservationExists(id))
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
        public async Task<IActionResult> DeleteSeatReservation(int id)
        {
            var seatReservation = await _context.SeatReservations.FindAsync(id);
            if (seatReservation == null)
            {
                return NotFound();
            }

            _context.SeatReservations.Remove(seatReservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("showtime/{showtimeId}")]
        public async Task<ActionResult<IEnumerable<SeatReservation>>> GetSeatReservationsByShowtime(int showtimeId)
        {
            var seatReservations = await _context.SeatReservations
                                                 .Where(sr => sr.ShowTimeId == showtimeId)
                                                 .ToListAsync();

            if (seatReservations == null || !seatReservations.Any())
            {
                return NotFound();
            }

            return Ok(seatReservations);
        }

        private bool SeatReservationExists(int id)
        {
            return _context.SeatReservations.Any(e => e.Id == id);
        }
    }
}
