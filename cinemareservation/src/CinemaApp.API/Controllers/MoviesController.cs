using CinemaApp.Core.Entities;
using CinemaApp.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CinemaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MoviesController(AppDBContext context)
        {
            _context = context;
        }


            [HttpGet]
            public async Task<IActionResult> GetMovies()
            {
                var movies = await _context.Movies.ToListAsync();
                return Ok(movies);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetMovie(int id)
            {
                var movie = await _context.Movies.FindAsync(id);
                if (movie == null) return NotFound();

                return Ok(movie);
            }

            [HttpPost]
            public async Task<IActionResult> CreateMovie([FromBody] Movie movie)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                Movie movie1 = new Movie()
                {

                Id=movie.Id,
                Title=movie.Title,
                Description=movie.Description,
                Duration=movie.Duration,
                ShowTimes=movie.ShowTimes,
                ReleaseDate=movie.ReleaseDate,
                Genres=movie.Genres,
                Rating=movie.Rating

                };

                movie1 = movie as Movie;
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie movie)
            {
                if (id != movie.Id)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _context.Entry(movie).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(id))
                        return NotFound();

                    throw;
                }

            return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteMovie(int id)
            {
                var movie = await _context.Movies.FindAsync(id);
                if (movie == null) return NotFound();

                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            private bool MovieExists(int id)
            {
                return _context.Movies.Any(e => e.Id == id);
                
            }
        }
    }

