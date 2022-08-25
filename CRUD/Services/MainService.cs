using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace CRUD.Services
{
    public class MainService : IMainService
    {
        private readonly ApplicationDbContext db;

        public MainService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddCourse(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public async Task Authenticate(HttpContext context, User user)
        {
            var claims = new List<Claim>()
                {
                    new Claim("userName",user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public void DeleteCourse(int id)
        {
            var course = GetCourse(id);
            db.Courses.Remove(course);
            db.SaveChanges();
        }

        public List<Course> GetAllCourses()
        {
            var courses = db.Courses.ToList();

            return courses;
        }

        public Course GetCourse(int id)
        {
            var course = db.Courses.Find(id);
            return course;
        }

        public void UpdateCourse(Course course)
        {
            db.Courses.Update(course);
            db.SaveChanges();
        }

        public bool ValidateUser(User user)
        {
            var data = db.Users.SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

            var result = data != null ? true : false;

            return result;
        }


    }
}
