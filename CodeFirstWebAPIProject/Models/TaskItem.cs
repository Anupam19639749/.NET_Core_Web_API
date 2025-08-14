using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CodeFirstWebAPIProject.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsCompleted { get; set; }

        // Foreign Key
        public int UserId { get; set; }

        // Navigation Property (Many Tasks → One User)
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
