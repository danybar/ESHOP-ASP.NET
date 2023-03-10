using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Models.Entities;
using UTB.Eshop.Web.Models.Identity;

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

        public List<Product> CreateProducts()
        {
            List<Product> products = new List<Product>();


            Product cs1 = new Product()
            {
                ID = 1,
                Name = "Paprika",
                Price = 100,
                ImageSrc = "/img/product/paprika.png",
                ImageAlt = "paprika",
                CategoryId = "zelenina",
            };

            Product cs2 = new Product()
            {
                ID = 2,
                Name = "Jahody",
                Price = 75,
                ImageSrc = "/img/product/jahody.png",
                ImageAlt = "jahody",
                CategoryId = "ovoce",
            };

            Product cs3 = new Product()
            {
                ID = 3,
                Name = "Mrkev",
                Price = 40,
                ImageSrc = "/img/product/mrkev.png",
                ImageAlt = "mrkev",
                CategoryId = "zelenina",
            };

            Product cs4 = new Product()
            {
                ID = 4,
                Name = "Špenát",
                Price = 10,
                ImageSrc = "/img/product/spenat.png",
                ImageAlt = "zelenina",
                CategoryId = "zelenina",
            };

            Product cs5 = new Product()
            {
                ID = 5,
                Name = "Rajče",
                Price = 50,
                ImageSrc = "/img/product/rajce.png",
                ImageAlt = "rajce",
                CategoryId = "zelenina",
            };

            products.Add(cs1);
            products.Add(cs2);
            products.Add(cs3);
            products.Add(cs4);
            products.Add(cs5);

            return products;
        }

        public List<Category> CreateCategory()
        {
            List<Category> category = new List<Category>();

            Category cs1 = new Category()
            {
                ID = 1,
                IdName = "zelenina",
                ImageSrc = "/img/product/22.5._tradicni ceska zelenina_shutterstock_409633858.jpg",
                ImageAlt = "zelenina",
            };

            Category cs2 = new Category()
            {
                ID = 2,
                IdName = "ovoce",
                ImageSrc = "/img/product/ovoce.png",
                ImageAlt = "ovoce",
            };

            Category cs3 = new Category()
            {
                ID = 3,
                IdName = "uzenina",
                ImageSrc = "/img/product/24.7._uzeniny_shutterstock_529443133.jpg",
                ImageAlt = "uzenina",
            };

            category.Add(cs1);
            category.Add(cs2);
            category.Add(cs3);

            return category;
        }

        public List<Role> CreateRoles()

        {
            List<Role> roles = new List<Role>();

            Role roleAdmin = new Role()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
            };

            Role roleManager = new Role()
            {
                Id = 2,
                Name = "Manager",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660"
            };

            Role roleCustomer = new Role()
            {
                Id = 3,
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
            };


            roles.Add(roleAdmin);
            roles.Add(roleManager);
            roles.Add(roleCustomer);

            return roles;
        }


        public (User, List<IdentityUserRole<int>>) CreateAdminWithRoles()
        {
            User admin = new User()
            {
                Id = 1,
                FirstName = "Adminek",
                LastName = "Adminovy",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.cz",
                NormalizedEmail = "ADMIN@ADMIN.CZ",
                EmailConfirmed = true,
                //password abc
                PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
                SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 3
                }
            };

            return (admin, adminUserRoles);
        }


        public (User, List<IdentityUserRole<int>>) CreateManagerWithRoles()
        {
            User manager = new User()
            {
                Id = 2,
                FirstName = "Managerek",
                LastName = "Managerovy",
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                Email = "manager@manager.cz",
                NormalizedEmail = "MANAGER@MANAGER.CZ",
                EmailConfirmed = true,
                //password abc
                PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
                SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            List<IdentityUserRole<int>> managerUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 3
                }
            };

            return (manager, managerUserRoles);
        }
    }
}
