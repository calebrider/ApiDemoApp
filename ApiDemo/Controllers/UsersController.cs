using Microsoft.AspNetCore.Mvc;
using ApiDemo.Services;
using ApiDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Dictionary<Guid, User> Get()
        {
            return _userService.GetAllUsers();
        }

        // GET api/Users/5
        /// <summary>
        /// Gets specific user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return _userService.GetUser(id);
        }

        // POST api/Users
        [HttpPost]
        public string Post(User user)
        {
            return _userService.CreateUser(user);
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public string Put(Guid id, string name, string email)
        {
            return _userService.UpdateUser(id, name, email);
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public string Delete(Guid id)
        {
            return _userService.DeleteUser(id);
        }
    }
}
