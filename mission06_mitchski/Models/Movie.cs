using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission06_mitchski.Models
{
    public class Movie
    {
        [Key]
        [Required(ErrorMessage = "There was an error with the movie ID")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please provide a movie title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please provide a movie year.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please provide a movie Director.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please provide a movie rating.")]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set;}

        [StringLength(25, ErrorMessage ="Notes can be no loger than 25 characters.")]
        public string Notes { get; set; }


        //Build Foreign Key relationship
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
