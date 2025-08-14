using CodeFirstWebAPIProject.Data;
using CodeFirstWebAPIProject.Interfaces;
using CodeFirstWebAPIProject.Models;
using Microsoft.EntityFrameworkCore;
namespace CodeFirstWebAPIProject.Services
{
    public class UserService : IUser
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.Include(u => u.Tasks).ToListAsync();
            // Include the Tasks for each User
            // Fetch all users with their tasks
        }
        public async Task<User> GetUsers(int id)
        {
            // Fetch a specific user by UserId and include their tasks
            //return Task.FromResult(_context.Users.Where(u => u.UserId == id).Include(u => u.Tasks).AsEnumerable());
            //return await _context.Users.Where(u => u.UserId == id).Include(u => u.Tasks).ToListAsync();
            return await _context.Users.Include(u => u.Tasks).FirstOrDefaultAsync(u=>u.UserId==id);
            // Include the Tasks for the specific User
        }

    }
}
