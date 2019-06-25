using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsDBAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ContactsDBAPI.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IMongoCollection<Email> _emails;

        public EmailRepository(IConfiguration config)
        {
            // Connects to MongoDB.
            var client = new MongoClient(config.GetConnectionString("ContactsDB"));
            // Gets the supplementDB.
            var database = client.GetDatabase("contacts");
            //Fetches the supplement collection.
            _emails = database.GetCollection<Email>("Emails");
        }

        public async Task<Email> CreateEmail(string personID, string email)
        {
            var newEmail = new Email(personID, email, DateTime.Today);
            await _emails.InsertOneAsync(newEmail);

            return newEmail;
        }

        public async Task DeleteEmail(string email)
        {

            await _emails.DeleteOneAsync(p => p.UserEmail == email);

        }

        public async Task<Email> FindEmail(string email)
        {
            var emailToFind = await _emails.Find(x => x.UserEmail == email).FirstOrDefaultAsync();

            return emailToFind;
        }

        public async Task<bool> EmailExist(string email)
        {
            var emailToFind = await _emails.Find(x => x.UserEmail == email).FirstOrDefaultAsync();

            if (emailToFind != null)
                return true;

            return false;
        }

        public async Task<List<Email>> FindAllUserEmails(string email)
        {
            Email firstEmail = await FindEmail(email);
            var numbers = await _emails.Find(u => u.PersonID == firstEmail.PersonID).ToListAsync();

            return numbers;
        }
    }
}
