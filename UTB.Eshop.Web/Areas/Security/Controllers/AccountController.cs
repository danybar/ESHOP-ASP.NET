using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Web.Controllers;
using UTB.Eshop.Web.Models.ApplicationServices.Abstraction;
using UTB.Eshop.Web.Models.ViewModels;

namespace UTB.Eshop.Web.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {
        readonly ISecurityApplicationService securityService;
        public AccountController(ISecurityApplicationService securityService)
        {
            this.securityService = securityService;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if(ModelState.IsValid)
            {
                string[] errors = await securityService.Register(registerVM, Models.Identity.Roles.Customer);
                if (errors == null)
                {
                    LoginViewModel loginViewModel = new LoginViewModel()
                    {
                        Username = registerVM.Username,
                        Password = registerVM.Password
                    };

                    return await Login(loginViewModel);
                }
                else
                {
                    //logovani chyb
                }
            }

            return View(registerVM);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                loginVM.LoginFailed = !await securityService.Login(loginVM);
                if (loginVM.LoginFailed == false)
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", String.Empty), new { area = String.Empty });
            }

            return View(loginVM);
        }


        public async Task<IActionResult> Logout()
        {
            await securityService.Logout();
            return RedirectToAction(nameof(Login));
        }

    }
}
