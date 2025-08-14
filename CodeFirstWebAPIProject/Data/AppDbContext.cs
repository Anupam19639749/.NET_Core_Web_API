using Microsoft.EntityFrameworkCore;
using CodeFirstWebAPIProject.Models;
namespace CodeFirstWebAPIProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-Many relationship configuration
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Anupam", Email = "anupam@example.com" },
                new User { UserId = 2, Name = "Anurag", Email = "anurag@example.com" }
                );

            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem
                {
                    TaskId = 1,
                    Title = "Finish ASP.NET Core Projects",
                    Description = "Complete the pending API development tasks",
                    Deadline = new DateTime(2025, 8, 20),
                    IsCompleted = false,
                    UserId = 1
                },
                new TaskItem
                {
                    TaskId = 2,
                    Title = "Prepare presentation",
                    Description = "Create slides for Monday meeting",
                    Deadline = new DateTime(2025, 8, 18),
                    IsCompleted = false,
                    UserId = 1
                },
                new TaskItem
                {
                    TaskId = 3,
                    Title = "Update project report",
                    Description = "Include latest changes from the dev team",
                    Deadline = new DateTime(2025, 8, 16),
                    IsCompleted = false,
                    UserId = 2
                }
            );
        }
    }
}
