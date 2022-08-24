using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult AllCourses()
        {
            return View();
        }
    }
}
