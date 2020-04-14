using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DisneyMovies.Models;

namespace DisneyMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisneyMoviesController : ControllerBase
    {
        private readonly DisneyMoviesContext _context;

        public DisneyMoviesController(DisneyMoviesContext context)
        {
            _context = context;
        }

        // GET: api/DisneyMovies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisneyMovie>>> GetDisneyMovies()
        {
            return await _context.DisneyMovies.ToListAsync();
        }

        // GET: api/DisneyMovies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisneyMovie>> GetDisneyMovie(long id)
        {
            var disneyMovie = await _context.DisneyMovies.FindAsync(id);

            if (disneyMovie == null)
            {
                return NotFound();
            }

            return disneyMovie;
        }

        // PUT: api/DisneyMovies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisneyMovie(long id, DisneyMovie disneyMovie)
        {
            if (id != disneyMovie.Id)
            {
                return BadRequest();
            }

            _context.Entry(disneyMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisneyMovieExists(id))
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

        // POST: api/DisneyMovies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DisneyMovie>> PostDisneyMovie(DisneyMovie disneyMovie)
        {
            _context.DisneyMovies.Add(disneyMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisneyMovie", new { id = disneyMovie.Id }, disneyMovie);
        }

        // DELETE: api/DisneyMovies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DisneyMovie>> DeleteDisneyMovie(long id)
        {
            var disneyMovie = await _context.DisneyMovies.FindAsync(id);
            if (disneyMovie == null)
            {
                return NotFound();
            }

            _context.DisneyMovies.Remove(disneyMovie);
            await _context.SaveChangesAsync();

            return disneyMovie;
        }

        private bool DisneyMovieExists(long id)
        {
            return _context.DisneyMovies.Any(e => e.Id == id);
        }
    }
}
