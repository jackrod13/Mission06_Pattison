using Microsoft.EntityFrameworkCore;

namespace Mission06_Pattison.Models
{
    // This class represents the database context, which acts as a bridge between the database and the application
    public class MovieListContext : DbContext
    {
        // Constructor: Passes the options to the base DbContext class
        public MovieListContext(DbContextOptions<MovieListContext> options) : base(options) { }

        // DbSet represents tables in the database
        public DbSet<Movie> Movies { get; set; } // Movies table
        public DbSet<Category> Categories { get; set; } // Categories table

        // Configuring the relationships and seeding initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defines the one-to-many relationship between Category and Movie
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Category)       // Each Movie has one Category
                .WithMany(c => c.Movies)       // Each Category can have multiple Movies
                .HasForeignKey(m => m.CategoryId) // Foreign key in Movie table
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete (Categories cannot be deleted if Movies exist under them)

            // Seeding initial category data for the database
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 2, CategoryName = "Drama" },
                new Category { CategoryId = 3, CategoryName = "Television" },
                new Category { CategoryId = 4, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 5, CategoryName = "Comedy" },
                new Category { CategoryId = 6, CategoryName = "Family" },
                new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );
        }
    }
}
