using CRUD.Data;
using CRUD.Models;

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
    }
}
