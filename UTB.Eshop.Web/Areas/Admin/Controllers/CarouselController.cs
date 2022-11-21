using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Domain.Abstraction;
using UTB.Eshop.Web.Models.Database;
using UTB.Eshop.Web.Models.Entities;
using UTB.Eshop.Web.Models.Identity;
using UTB.Eshop.Web.Models.ViewModels;

namespace UTB.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
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
        public async Task<IActionResult> Create(CarouselSlideFileRequired carouselSlide)
        {
            ModelState.Remove(nameof(CarouselSlide.ImageSrc));
            if (ModelState.IsValid)
            {
                if (checkFileLength.CheckFileLength(carouselSlide.Image, 5_000_000))
                {

                    fileUpload.ContentType = "image";
                    fileUpload.FileLength = 5_000_000;
                    carouselSlide.ImageSrc = await fileUpload.FileUploadAsync(carouselSlide.Image, Path.Combine("img", "carousel"));

                    ModelState.Clear();
                    bool validated = TryValidateModel(carouselSlide);
                    if (validated)
                    {
                        eshopDb.CarouselSlides.Add(carouselSlide);

                        eshopDb.SaveChanges();

                        return RedirectToAction(nameof(CarouselController.Index));
                    }

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
                ModelState.Remove(nameof(CarouselSlide.ImageSrc));
                if (ModelState.IsValid)
                {
                    if (carouselSlide.Image != null)
                    {
                        if (checkFileLength.CheckFileLength(carouselSlide.Image, 5_000_000))
                        {

                            fileUpload.ContentType = "image";
                            fileUpload.FileLength = 5_000_000;
                            carouselSlide.ImageSrc = await fileUpload.FileUploadAsync(carouselSlide.Image, Path.Combine("img", "carousel"));

                            ModelState.Clear();
                            if (TryValidateModel(carouselSlide))
                            {
                                carSlide.ImageSrc = carouselSlide.ImageSrc;
                            }
                            else
                            {
                                return View(carouselSlide);
                            }
                        }
                        else
                        {
                            return View(carouselSlide);
                        }
                    }

                    carSlide.ImageAlt = carouselSlide.ImageAlt;

                    eshopDb.SaveChanges();

                    return RedirectToAction(nameof(CarouselController.Index));
                }
                else
                    return View(carouselSlide);
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
