using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CodeFirstWebAPIProject.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        // Navigation Property (One User → Many Tasks)
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
