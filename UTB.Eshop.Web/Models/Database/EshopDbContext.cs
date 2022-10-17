using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Models.Entities;

namespace UTB.Eshop.Web.Models.Database
{
    public class EshopDbContext : DbContext
    {
        public DbSet<CarouselSlide> CarouselSlides { get; set; }

        public EshopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            DatabaseInit databaseInit = new DatabaseInit();
            builder.Entity<CarouselSlide>().HasData(databaseInit.CreateCarouselSlides());
        }
    }
}
