using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission06_mitchski.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission06_mitchski.Controllers
{
    public class HomeController : Controller
    {
        private MovieContexts _mvContext { get; set; }

        //Constructor
        public HomeController( MovieContexts x)
        {
            _mvContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View("myPodcasts");
        }


        [HttpPost]
        public IActionResult Edit(Movie ar)
        {

            //Could validate some data here with a post or something.
            if (ModelState.IsValid){
                //Post data to the database
                _mvContext.Add(ar);
                _mvContext.SaveChanges();

                //Now to view the movies you need to pull them from the database
                var movies = _mvContext.Movies
                    .Include(x => x.Category)
                    .OrderBy(x => x.Category)
                    .ToList();
                return View("viewMovies", movies); // maybe make a confirmatin page?
            }


            ViewBag.Categories = _mvContext.Categories.ToList();

            return View("edit", ar);
        }

        [HttpGet]
        public IActionResult Edit() //Add a new record (i.e. edit the catalog)
        {
            //var categories = _mvContext.Categories.ToList();

            ViewBag.Categories = _mvContext.Categories.ToList();


            //return View("edit", categories);
            return View("edit", new Movie());
        }

        [HttpGet]
        public IActionResult UpdateRecord(int id)
        {
            //Pull the category list to populat selectoption
            ViewBag.Categories = _mvContext.Categories.ToList();

            //Find the record which you want to edit, and pass the stored data
            var recordToUpdate = _mvContext.Movies.Single(x => x.MovieId == id);

            return View("edit", recordToUpdate);
        }

        [HttpPost]
        public IActionResult UpdateRecord(Movie updatedRecord)
        {
            
            //Maybe validate here before updating?
            _mvContext.Update(updatedRecord);
            _mvContext.SaveChanges();



            return RedirectToAction("Catalog");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            
            var movieToDelete = _mvContext.Movies.Single(x => x.MovieId == id);

            return View(movieToDelete);
        }


        [HttpPost]
        public IActionResult Delete(Movie DeletedMovie)
        {
            _mvContext.Movies.Remove(DeletedMovie);
            _mvContext.SaveChanges();

            return RedirectToAction("Catalog");
        }

        public IActionResult Catalog ()
        {
            var movies = _mvContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Category)
                .ToList();
            
            
            
            //An example of filtering and ordering

            //var movies = _mvContext.Movies
            //    .Where(x => x.Rating != "R")
            //    .OrderBy(x => x.Category)
            //    .ToList();
            return View("viewMovies", movies);
        }
    }
}
