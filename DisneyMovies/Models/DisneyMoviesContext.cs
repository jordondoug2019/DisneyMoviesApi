using Microsoft.EntityFrameworkCore;
 
namespace DisneyMovies.Models
{
    public class DisneyMoviesContext : DbContext
    {
        public DisneyMoviesContext(DbContextOptions<DisneyMoviesContext> options)
            : base(options)
        {
        }
 
        public DbSet<DisneyMovie> DisneyMovies { get; set; }
    }
}
