using CodeFirstWebAPIProject.Data;
using CodeFirstWebAPIProject.Interfaces;
using CodeFirstWebAPIProject.Models;
using Microsoft.EntityFrameworkCore;
namespace CodeFirstWebAPIProject.Services
{
    public class TaskItemService : ITaskItem
    {
        private readonly AppDbContext _context;
        public TaskItemService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            return await _context.Tasks.Include(t => t.User).ToListAsync(); // Include the User details for each TaskItem
        }

        public Task<IEnumerable<TaskItem>> GetTasks(int id)
        {
            // Fetch tasks for a specific user by UserId
            return Task.FromResult(_context.Tasks.Where(t => t.UserId == id).Include(t => t.User).AsEnumerable()); 
            
            // Include the User details for each TaskItem

        }
    }
}
