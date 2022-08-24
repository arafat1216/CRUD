using CRUD.Models;

namespace CRUD.Services
{
    public interface IMainService
    {
        List<Course> GetAllCourses();
        void AddCourse(Course course);

        Course GetCourse(int id);

        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}
