using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Models.Database;
using UTB.Eshop.Web.Models.Entities;

namespace UTB.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarouselController : Controller
    {
        readonly EshopDbContext eshopDb;
        public CarouselController(EshopDbContext eshopDbContext)
        {
            eshopDb = eshopDbContext;
        }

        public IActionResult Index()
        {
            List<CarouselSlide> carouselSlides = eshopDb.CarouselSlides.ToList();

            return View(carouselSlides);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarouselSlide carouselSlide)
        {
            eshopDb.CarouselSlides.Add(carouselSlide);

            eshopDb.SaveChanges();

            return RedirectToAction(nameof(CarouselController.Index));
        }


        public IActionResult Edit(int ID)
        {
            CarouselSlide carSlide = eshopDb.CarouselSlides.FirstOrDefault(carouselItem => carouselItem.ID == ID);
            
            if (carSlide != null)
            {
                return View(carSlide);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(CarouselSlide carouselSlide)
        {
            CarouselSlide carSlide = eshopDb.CarouselSlides.FirstOrDefault(carouselItem => carouselItem.ID == carouselSlide.ID);

            if (carSlide != null)
            {
                carSlide.ImageSrc = carouselSlide.ImageSrc;
                carSlide.ImageAlt = carouselSlide.ImageAlt;

                eshopDb.SaveChanges();

                return RedirectToAction(nameof(CarouselController.Index));
            }

            return NotFound();
        }


        public IActionResult Delete(int ID)
        {
            CarouselSlide carSlide = eshopDb.CarouselSlides.FirstOrDefault(carouselSlide => carouselSlide.ID == ID);

            if (carSlide != null)
            {
                eshopDb.CarouselSlides.Remove(carSlide);

                eshopDb.SaveChanges();

                return RedirectToAction(nameof(CarouselController.Index));
            }

            return NotFound();
        }
    }
}
