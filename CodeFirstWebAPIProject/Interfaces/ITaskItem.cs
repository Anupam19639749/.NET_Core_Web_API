using CodeFirstWebAPIProject.Models;
namespace CodeFirstWebAPIProject.Interfaces
{
    public interface ITaskItem
    {
        Task<IEnumerable<TaskItem>> GetAllTasks();
        Task<IEnumerable<TaskItem>> GetTasks(int id);
    }
}
