using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ContactsDBAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ContactsDBAPI.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {

        private readonly IMongoCollection<Phone> _phones;

        public PhoneRepository(IConfiguration config)
        {
            // Connects to MongoDB.
            var client = new MongoClient(config.GetConnectionString("ContactsDB"));
            // Gets the supplementDB.
            var database = client.GetDatabase("contacts");
            //Fetches the supplement collection.
            _phones = database.GetCollection<Phone>("Phones");
        }


        public async Task<Phone> CreatePhone(string personID, string phone)
        {
            var newPhone = new Phone(personID, phone, DateTime.Today);
            await _phones.InsertOneAsync(newPhone);

            return newPhone;
        }

        public async Task DeletePhone(string phone)
        {

            await _phones.DeleteOneAsync<Phone>(p=> p.Number == phone);

        }

        public async Task<List<Phone>> FindAllUserNumber(string id)
        {

            var numbers = await _phones.Find(u => u.PersonID == id).ToListAsync();

            return numbers;
        }

        public async Task<Phone> FindPhone(string phone)
        {
            phone = PhoneConvert(phone);
            var phoneToFind = await _phones.Find(x => x.Number == phone).FirstOrDefaultAsync();
            return phoneToFind;
        }

        public async Task<bool> PhoneExist(string phone)
        {
            phone = PhoneConvert(phone);
            var phoneToFind = await _phones.Find(x => x.Number == phone).FirstOrDefaultAsync();

            if (phoneToFind != null)
                return true;

            return false;


        }


        private string PhoneConvert(string n)
        {
            string result = Regex.Replace(n, @"^(\+)|\D", "$1");


            return result;

        }

    }
}
