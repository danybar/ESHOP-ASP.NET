using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Models.Entities;

namespace UTB.Eshop.Web.Models.Database
{
    public class DatabaseInit
    {
        public List<CarouselSlide> CreateCarouselSlides()
        {
            List<CarouselSlide> carouselSlides = new List<CarouselSlide>();


            CarouselSlide cs1 = new CarouselSlide()
            {
                ID = 1,
                ImageSrc = "/img/carousel/how-to-become-an-information-technology-specialist160684886950141.jpg",
                ImageAlt = "First slide"
            };

            CarouselSlide cs2 = new CarouselSlide()
            {
                ID = 2,
                ImageSrc = "/img/carousel/Information-Technology-1-1.jpg",
                ImageAlt = "Second slide"
            };

            CarouselSlide cs3 = new CarouselSlide()
            {
                ID = 3,
                ImageSrc = "/img/carousel/1581481407499.jpeg",
                ImageAlt = "Third slide"
            };

            carouselSlides.Add(cs1);
            carouselSlides.Add(cs2);
            carouselSlides.Add(cs3);

            return carouselSlides;
        }
    }
}
