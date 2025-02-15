using Microsoft.EntityFrameworkCore;

namespace Mission06_Pattison.Models
{
    public class MovieListContext : DbContext
    {
        public MovieListContext(DbContextOptions<MovieListContext> options) : base (options) // Constructor
        {

        }

        public DbSet<AddMovieForm> MovieList { get; set; }
    }
}
