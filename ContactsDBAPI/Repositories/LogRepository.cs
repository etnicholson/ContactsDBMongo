using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsDBAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ContactsDBAPI.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly IMongoCollection<Log> _logs;

        public LogRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ContactsDB"));
            // Gets the supplementDB.
            var database = client.GetDatabase("contacts");
            //Fetches the supplement collection.
            _logs = database.GetCollection<Log>("Logs");
        }
        public async Task Create(string owner, string phone, string email, string action)
        {
            var log = new Log(owner, phone, email, action);
            log.Date = DateTime.UtcNow;

            await _logs.InsertOneAsync(log);
        }

        public Task<Log> RetriveByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Log> RetriveByOwner(string owner)
        {
            throw new NotImplementedException();
        }

        public Task<Log> RetriveByPhone(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Log>> RetriveLogs()
        {
            var logs = await _logs.Find(s => true).ToListAsync();

            return logs;

        }
    }
}
