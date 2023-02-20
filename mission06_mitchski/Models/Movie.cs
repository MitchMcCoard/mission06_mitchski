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
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please provide a movie title.")]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set;}

        [StringLength(25)]
        public string Notes { get; set; }


        //Build Foreign Key relationship
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
