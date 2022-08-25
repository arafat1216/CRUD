using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "The Password field must be at least 6 characters long")]
        public string Password { get; set; }
    }
}
