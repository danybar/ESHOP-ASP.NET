using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Domain.Abstraction;
using UTB.Eshop.Web.Models.Database;
using UTB.Eshop.Web.Models.Entities;

namespace UTB.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarouselController : Controller
    {
        readonly EshopDbContext eshopDb;
        IFileUpload fileUpload;
        ICheckFileContent checkFileContent;
        ICheckFileLength checkFileLength;
        public CarouselController(EshopDbContext eshopDbContext,
                                    IFileUpload fileUpload,
                                    ICheckFileContent checkFileContent,
                                    ICheckFileLength checkFileLength)
        {
            eshopDb = eshopDbContext;
            this.fileUpload = fileUpload;
            this.checkFileContent = checkFileContent;
            this.checkFileLength = checkFileLength;
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
        public async Task<IActionResult> Create(CarouselSlide carouselSlide)
        {
            if (checkFileContent.CheckFileContent(carouselSlide.Image, "image")
                && checkFileLength.CheckFileLength(carouselSlide.Image, 5_000_000))
            {

                fileUpload.ContentType = "image";
                fileUpload.FileLength = 5_000_000;
                carouselSlide.ImageSrc = await fileUpload.FileUploadAsync(carouselSlide.Image, Path.Combine("img", "carousel"));

                if (String.IsNullOrEmpty(carouselSlide.ImageSrc) == false)
                {
                    eshopDb.CarouselSlides.Add(carouselSlide);

                    eshopDb.SaveChanges();

                    return RedirectToAction(nameof(CarouselController.Index));
                }

            }

            return View(carouselSlide);
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
        public async Task<IActionResult> Edit(CarouselSlide carouselSlide)
        {
            CarouselSlide carSlide = eshopDb.CarouselSlides.FirstOrDefault(carouselItem => carouselItem.ID == carouselSlide.ID);

            if (carSlide != null)
            {
                if (checkFileContent.CheckFileContent(carouselSlide.Image, "image")
                && checkFileLength.CheckFileLength(carouselSlide.Image, 5_000_000))
                {

                    fileUpload.ContentType = "image";
                    fileUpload.FileLength = 5_000_000;
                    carouselSlide.ImageSrc = await fileUpload.FileUploadAsync(carouselSlide.Image, Path.Combine("img", "carousel"));

                    if (String.IsNullOrEmpty(carouselSlide.ImageSrc) == false)
                    {
                        carSlide.ImageSrc = carouselSlide.ImageSrc;
                    }
                }

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
