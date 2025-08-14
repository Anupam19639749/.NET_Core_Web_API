using CodeFirstWebAPIProject.Interfaces;
using CodeFirstWebAPIProject.Models;
using CodeFirstWebAPIProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CodeFirstWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _userService.GetUsers(id);
        }
    }
}
