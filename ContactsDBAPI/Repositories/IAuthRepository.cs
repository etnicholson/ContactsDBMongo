using ContactsDBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Repositories
{
    public interface IAuthRepository
    {
        Task<User> Register(string email, string password);
        Task<List<string>> RetriveAllUsers();


        Task DeleteUser(string email);

        Task<User> Login (string email, string password);
        Task<bool> UserExists(string email);
    }
}
