using System;
using System.Collections.Generic;
using UTB.Eshop.Web.Models.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UTB.Eshop.Web.Models.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }

        public int CurrentPageIndex { get; set; }

        public int PageCount { get; set; }

    }
}