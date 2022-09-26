using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Models.Entities;

namespace UTB.Eshop.Web.Models.Database
{
    public static class DatabaseFake
    {
        public static List<CarouselSlide> CarouselSlides { get; set; }

        static DatabaseFake()
        {
            DatabaseInit dbInit = new DatabaseInit();
            CarouselSlides = dbInit.CreateCarouselSlides();
        }
    }
}
