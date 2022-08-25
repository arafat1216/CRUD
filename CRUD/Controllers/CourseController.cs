using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly IMainService mainService;

        public CourseController(IMainService mainService)
        {
            this.mainService = mainService;
        }
        public IActionResult AllCourses()
        {
            var courses = mainService.GetAllCourses();
            return View(courses);
        }

        public IActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            
            if(ModelState.IsValid)
            {
                mainService.AddCourse(course);
                TempData["success"] = "New Course Added Successfully";
                return RedirectToAction("AllCourses");
            }
               
            return View(course);
        }

        public IActionResult EditCourse(int id)
        {
            var course = mainService.GetCourse(id);
            return View(course);
        }
        [HttpPost]
        public IActionResult EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                mainService.UpdateCourse(course);
                TempData["success"] = "Course Updated Successfully";
                return RedirectToAction("AllCourses");
            }
            return View(course);
        }

        public IActionResult DeleteCourse(int id)
        {

            mainService.DeleteCourse(id);
            TempData["success"] = "Course Deleted Successfully";
            return RedirectToAction("AllCourses");
        }
    }
}
