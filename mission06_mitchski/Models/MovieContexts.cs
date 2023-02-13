using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission06_mitchski.Models
{
    public class MovieContexts : DbContext
    {
        //Constructor
        public MovieContexts (DbContextOptions<MovieContexts> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie>().HasData(

                new Movie
                {
                    MovieId = 1,
                    Category = "Action/Adventure",
                    Title = "X-Men",
                    Year = 2000,
                    Director = "Bryan Singer",
                    Rating = "PG-13",
                    Edited = false

                },
                new Movie
                {
                    MovieId = 2,
                    Category = "Action/Adventure",
                    Title = "Star Wars Episode VI: Return of the Jedi",
                    Year = 1983,
                    Director = "Richard Marquand",
                    Rating = "PG",
                    Edited = false
                },
                new Movie
                {
                    MovieId = 3,
                    Category = "Comedy",
                    Title = "Back to the Future",
                    Year = 1985,
                    Director = "Robert Zemeckis",
                    Rating = "PG",
                    Edited = false
                }

            );
        }
    }
}
