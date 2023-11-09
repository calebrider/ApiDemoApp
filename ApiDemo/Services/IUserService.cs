using ApiDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Services
{
    public interface IUserService
    {
        Dictionary<Guid, User> GetAllUsers();
        string GetUser(Guid id);
        string CreateUser(User user);
        string UpdateUser(Guid id, string name, string email);
        string DeleteUser(Guid id);
    }
}
