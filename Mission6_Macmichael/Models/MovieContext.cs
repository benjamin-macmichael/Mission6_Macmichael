using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Mission6_Macmichael.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Seed data
        {
            modelBuilder.Entity<Categories>().HasData(

                new Categories { CategoryId = 1, Category = "Miscellaneous" },
                new Categories { CategoryId = 2, Category = "Drama" },
                new Categories { CategoryId = 3, Category = "Television" },
                new Categories { CategoryId = 4, Category = "Horror/Suspense" },
                new Categories { CategoryId = 5, Category = "Comedy" },
                new Categories { CategoryId = 6, Category = "Family" },
                new Categories { CategoryId = 7, Category = "Action/Adventure" },
                new Categories { CategoryId = 8, Category = "VHS" }

            );
        }
    }
}
