﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UTB.Eshop.Web.Models.Database;
using UTB.Eshop.Web.Models.Entities;
using UTB.Eshop.Web.Models.ViewModels;
using X.PagedList;
using System;

namespace UTB.Eshop.Web.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class CategoryController : Controller
    {
        readonly EshopDbContext eshopDb;

        public CategoryController(EshopDbContext eshopDbContext)
        {
            eshopDb = eshopDbContext;
        }

        [HttpGet]
        public IActionResult Index(int? page, string category)
        {

            int pageSize = 3;
            int pageIndex = 1;

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            if (category != null) {
                IPagedList<Product> products = eshopDb.Products.Where(p => p.CategoryId == category).ToPagedList(pageIndex, pageSize);
                return View(products);
            }

            else {
                IPagedList<Product> products = eshopDb.Products.ToPagedList(pageIndex, pageSize);
                return View(products);
            }

        }
    }

}

