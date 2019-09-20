using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsDBAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ContactsDBAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMongoCollection<User> _users;

        public AuthRepository(IConfiguration config)
        {
            // Connects to MongoDB.
            var client = new MongoClient(config.GetConnectionString("ContactsDB"));
            // Gets the supplementDB.
            var database = client.GetDatabase("contacts");
            //Fetches the supplement collection.
            _users = database.GetCollection<User>("User");
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _users.Find(x => x.Email == email).FirstOrDefaultAsync();

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> Register(string email, string password)
        {
            var user = new User();
            
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.Email = email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;


            await _users.InsertOneAsync(user);


            return user;
        }

        public async Task DeleteUser(string email)
        {

            await _users.DeleteOneAsync<User>(p=> p.Email == email);
        }

        public async Task<bool> UserExists(string email)
        {
            var user = await _users.Find(x => x.Email == email).FirstOrDefaultAsync();

            if (user != null)
                return true;

            return false;
        }



        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<List<string>> RetriveAllUsers()
        {
            var users = await _users.Find(_ => true).ToListAsync();
            var l = new List<string>();

            foreach (var item in users)
            {
                l.Add(item.Email);
            }

            l.Remove("admin@admin.com");
            
            return l;
        }
    }
}
