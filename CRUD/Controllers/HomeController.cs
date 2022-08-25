using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMainService mainService;

        public HomeController(IMainService mainService)
        {
            this.mainService = mainService;
        }
        public IActionResult Index()
        {
            var courses = mainService.GetAllCourses();
            return View(courses);
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                var result = mainService.ValidateUser(user);

                if (result)
                {
                    mainService.Authenticate(HttpContext, user);
                    return RedirectToAction("AllCourses", "Course");
                }

            }
            TempData["loginError"] = "Invalid User Name Or Password";
            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
