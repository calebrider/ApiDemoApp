using ApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiDemo.Services
{
    public class UserService : IUserService
    {
        private static readonly Dictionary<Guid, User> _users = new Dictionary<Guid, User>();

        public Dictionary<Guid, User> GetAllUsers()
        {
            return _users;
        }

        public string GetUser(Guid id)
        {
            if (_users.TryGetValue(id, out var user))
            {
                return $"Got user named {user.Name}";
            }

            return $"No user with ID: {id} to get";

        }
        public string CreateUser(User user)
        {
            _users.Add(Guid.NewGuid(), user);

            return $"Added new user {JsonSerializer.Serialize(user)}";
        }

        public string UpdateUser(Guid id, string name, string email)
        {
            if (_users.ContainsKey(id))
            {
                User newUser = new User();
                newUser.Name = name;
                newUser.Email = email;

                _users[id] = newUser;
                return $"Updated user with ID: {id}";
            }
            
            return $"User with ID: {id} does not exist";
        }

        public string DeleteUser(Guid id)
        {
            if (_users.TryGetValue(id, out var user))
            {
                _users.Remove(id);
                return $"Deleted user {JsonSerializer.Serialize(user)}";
            }

            return $"No user with ID: {id} to delete";
        }
    }
}
