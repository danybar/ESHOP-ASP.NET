using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Models.Entities;

namespace UTB.Eshop.Web.Models.ViewModels
{
    public class CarouselSlideFileRequired : CarouselSlide
    {
        [Required]
        public override IFormFile Image { get; set; }
    }
}
