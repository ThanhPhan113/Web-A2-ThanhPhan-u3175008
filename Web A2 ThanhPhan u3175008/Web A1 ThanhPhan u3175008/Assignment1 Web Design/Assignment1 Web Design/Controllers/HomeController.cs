using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment1_Web_Design.Models;
using Assignment1_Web_Design.Data;
//using WDPTutorials.Data;
using Microsoft.EntityFrameworkCore;



namespace Assignment1_Web_Design.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Home()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public async Task<IActionResult> Organisations()
        {
            var sorttedposts = from post in
           _context.CompaniesOrganisations
                               orderby post.Date descending
                               select post;

            return View(await sorttedposts.ToListAsync());
        }


        public  async Task<IActionResult> EmergingTechnologies()
        {
            var sorttedposts = from post in 
            _context.EmergingTechFB
                             orderby post.Date descending
                             select post;

            return View(await sorttedposts.ToListAsync());

        }


        public IActionResult WorldMap()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
