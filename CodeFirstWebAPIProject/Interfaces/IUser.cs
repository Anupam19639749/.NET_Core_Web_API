using CodeFirstWebAPIProject.Models;
namespace CodeFirstWebAPIProject.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUsers(int id);

        
    }
}
