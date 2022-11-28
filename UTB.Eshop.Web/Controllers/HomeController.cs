using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Models;
using UTB.Eshop.Web.Models.Database;
using UTB.Eshop.Web.Models.Entities;
using UTB.Eshop.Web.Models.ViewModels;

namespace UTB.Eshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly EshopDbContext eshopDb;
        public HomeController(ILogger<HomeController> logger, EshopDbContext eshopDbContext)
        {
            _logger = logger;
            eshopDb = eshopDbContext;
        }

        public IActionResult Index()
        {
            List<CarouselSlide> carouselSlides = eshopDb.CarouselSlides.ToList();
            List<Product> products = eshopDb.Products.ToList();

            HomeIndexViewModel hiVM = new HomeIndexViewModel()
            {
                CarouselSlides = carouselSlides,
                Products = products
            };

            return View(hiVM);
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
