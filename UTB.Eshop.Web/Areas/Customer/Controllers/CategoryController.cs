using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UTB.Eshop.Web.Models.Database;
using UTB.Eshop.Web.Models.Entities;
using UTB.Eshop.Web.Models.ViewModels;
using X.PagedList;
using System;
using System.Threading.Tasks;
using System.IO;
using UTB.Eshop.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace UTB.Eshop.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CategoryController : Controller
    {
        readonly EshopDbContext eshopDb;

        IFileUpload fileUpload;
        ICheckFileContent checkFileContent;
        ICheckFileLength checkFileLength;
        public CategoryController(EshopDbContext eshopDbContext,
            IFileUpload fileUpload,
            ICheckFileContent checkFileContent,
            ICheckFileLength checkFileLength)
        {
            eshopDb = eshopDbContext;
            this.fileUpload = fileUpload;
            this.checkFileContent = checkFileContent;
            this.checkFileLength = checkFileLength;
        }

        [HttpGet]
        public IActionResult Index(int? page, string category, bool sort)
        {

            int pageSize = 3;
            int pageIndex = 1;

            ViewBag.status = false;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            if (category != null)
            {
                ViewBag.category = category;
                List<Product> products = eshopDb.Products.Where(p => p.CategoryId == category).OrderBy(p => p.ID).ToList();

                if (sort == true) {
                    ViewBag.status = true;
                    products = products.OrderByDescending(p => eshopDb.OrderItems.Where(oI => oI.ProductID == p.ID).Sum(oI => oI.Amount)).ToList();
                }
                return View(products.ToPagedList(pageIndex, pageSize));
            }
            return Redirect("../Home#category");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryFileRequired category)
        {
            ModelState.Remove(nameof(Category.ImageSrc));
            fileUpload.ContentType = "image";
            fileUpload.FileLength = 5_000_000;
            category.ImageSrc = await fileUpload.FileUploadAsync(category.Image, Path.Combine("img", "product"));

            if (ModelState.IsValid)
            {
                eshopDb.Add(category);
                await eshopDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await eshopDb.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryFileRequired category)
        {
            if (id != category.ID)
            {
                return NotFound();
            }
            try
            {
                fileUpload.ContentType = "image";
                fileUpload.FileLength = 5_000_000;

                category.ImageSrc = await fileUpload.FileUploadAsync(category.Image, Path.Combine("img", "product"));

                eshopDb.Update(category);
                await eshopDb.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await eshopDb.Category
                .FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await eshopDb.Category.FindAsync(id);
            eshopDb.Category.Remove(category);
            await eshopDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return eshopDb.Category.Any(e => e.ID == id);
        }


    }

}

