using ContactsDBAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Repositories
{
    public class PersonRepository: IPersonRepository
    {
        private readonly IMongoCollection<Person> _persons;

        public PersonRepository(IConfiguration config)
        {
            // Connects to MongoDB.
            var client = new MongoClient(config.GetConnectionString("ContactsDB"));
            // Gets the supplementDB.
            var database = client.GetDatabase("contacts");
            //Fetches the supplement collection.
            _persons = database.GetCollection<Person>("Persons");
        }

        public async Task<Person> CreatePerson(string name, string city, string notes)
        {
            var person = new Person(name, city, notes);
            await _persons.InsertOneAsync(person);
            return person;
        }

        public async Task DeletePerson(string id)
        {
            await _persons.DeleteOneAsync(p => p.Id == id);
        }

        public async Task<Person> FindPerson(string id)
        {
            var person = await _persons.Find(p => p.Id == id).FirstOrDefaultAsync();

            return person;
        }

        public async Task<bool> PersonExist(string id)
        {
            var personToFind = await _persons.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (personToFind != null)
                return true;

            return false;
        }

        public async Task<List<string>> RetreiveCities()
        {
            var cities = new List<string>();
            var persons = await _persons.Find(s => true).ToListAsync();

            foreach (var item in persons)
            {
                if (!cities.Contains(item.City))
                {
                    cities.Add(item.City);
                }

            }

            return cities;

        }
    }
}
