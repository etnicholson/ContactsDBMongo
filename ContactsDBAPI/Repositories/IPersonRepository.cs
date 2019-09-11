using ContactsDBAPI.Dto;
using ContactsDBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> CreatePerson(string name, string city, string notes);
        Task UpdateNotes(PersonUpdateDto person);

        Task<Person> FindPerson(string id);

        Task<bool> PersonExist(string id);

        Task DeletePerson(string id);

        Task<List<string>> RetreiveCities();

        Task<List<Person>> RetrieveAllPeople();

    }
}
