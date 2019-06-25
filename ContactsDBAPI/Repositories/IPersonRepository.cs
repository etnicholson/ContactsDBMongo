﻿using ContactsDBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> CreatePerson(string name, string city, string notes);

        Task<Person> FindPerson(string id);

        Task DeletePerson(string id);

    }
}
