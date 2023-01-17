using System;
using System.Collections.Generic;
using UTB.Eshop.Web.Models.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UTB.Eshop.Web.Models.ViewModels
{
    public class CategoryViewModel
    {
        public List<Category> Category { get; set; }

    }
}