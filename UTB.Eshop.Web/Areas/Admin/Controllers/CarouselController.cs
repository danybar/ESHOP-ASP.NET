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
        public IActionResult Index()
        {
            List<CarouselSlide> carouselSlides = DatabaseFake.CarouselSlides;

            return View(carouselSlides);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarouselSlide carouselSlide)
        {
            if (DatabaseFake.CarouselSlides.Count > 0)
            {
                carouselSlide.ID = DatabaseFake.CarouselSlides.Last().ID + 1;
            }
            else
            {
                carouselSlide.ID = 1;
            }

            DatabaseFake.CarouselSlides.Add(carouselSlide);

            return RedirectToAction(nameof(CarouselController.Index));
        }


        public IActionResult Edit(int ID)
        {
            CarouselSlide carSlide = DatabaseFake.CarouselSlides.FirstOrDefault(carouselItem => carouselItem.ID == ID);
            
            if (carSlide != null)
            {
                return View(carSlide);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(CarouselSlide carouselSlide)
        {
            CarouselSlide carSlide = DatabaseFake.CarouselSlides.FirstOrDefault(carouselItem => carouselItem.ID == carouselSlide.ID);

            if (carSlide != null)
            {
                carSlide.ImageSrc = carouselSlide.ImageSrc;
                carSlide.ImageAlt = carouselSlide.ImageAlt;

                return RedirectToAction(nameof(CarouselController.Index));
            }

            return NotFound();
        }


        public IActionResult Delete(int ID)
        {
            CarouselSlide carSlide = DatabaseFake.CarouselSlides.FirstOrDefault(carouselSlide => carouselSlide.ID == ID);

            if (carSlide != null)
            {
                DatabaseFake.CarouselSlides.Remove(carSlide);

                return RedirectToAction(nameof(CarouselController.Index));
            }

            return NotFound();
        }
    }
}
