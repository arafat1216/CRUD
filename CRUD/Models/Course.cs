using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required(ErrorMessage ="Please Enter Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Please Enter Course Description")]
        public string CourseDescription { get; set; }

        
        [Range(500,25000,ErrorMessage ="Please Enter Course Price Between 500 And 25000")]
        public decimal CoursePrice { get; set; }
    }
}
