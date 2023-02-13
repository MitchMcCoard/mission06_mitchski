using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private MovieContexts _blahContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieContexts x)
        {
            _logger = logger;
            _blahContext = x;
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
                _blahContext.Add(ar);
                _blahContext.SaveChanges();
            }
            

            return View("edit");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View("edit");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
