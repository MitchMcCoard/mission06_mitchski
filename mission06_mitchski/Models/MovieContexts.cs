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
        public DbSet<Category> Categories { get; set; }



        //Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Seed the Category table
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy"},
                new Category { CategoryID = 3, CategoryName = "Drama" },
                new Category { CategoryID = 4, CategoryName = "Family" },
                new Category { CategoryID = 5, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 6, CategoryName = "Television" },
                new Category { CategoryID = 7, CategoryName = "VHS" }
                );

            //Seed the Movie table
            mb.Entity<Movie>().HasData(

                new Movie
                {
                    MovieId = 1,
                    CategoryID = 1,
                    Title = "X-Men",
                    Year = 2000,
                    Director = "Bryan Singer",
                    Rating = "PG-13",
                    Edited = false

                },
                new Movie
                {
                    MovieId = 2,
                    CategoryID = 1,
                    Title = "Star Wars Episode VI: Return of the Jedi",
                    Year = 1983,
                    Director = "Richard Marquand",
                    Rating = "PG",
                    Edited = false
                },
                new Movie
                {
                    MovieId = 3,
                    CategoryID = 2,
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
