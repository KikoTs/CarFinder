using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CarFinder.Data;
using CarFinder.Models;
using CarFinder.Services;
using CarFinder.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarFinder.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context = new AppDbContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string searchString)
        {
            _logger.LogInformation(searchString);
            IEnumerable<Cars> cars = Enumerable.Empty<Cars>().AsEnumerable();
            if (!String.IsNullOrEmpty(searchString))
            {
 
                var search = searchString.Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

                switch (search.Length)
                {
                    case 1:
                        cars = from m in _context.Cars
                               where m.Make == search[0]
                               select m; 
                        break;
                    case 2:
                        cars = from m in _context.Cars
                               where m.Make == search[0] && m.Model == search[1]
                               select m;
                        break;
                    case 3:
                        cars = from m in _context.Cars
                               where m.Make == search[0] && m.Model == search[1] && m.Year == Int32.Parse(search[2])
                               select m;
                        break;
                }
            }
            else
            {

            }

            return View(cars.ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
