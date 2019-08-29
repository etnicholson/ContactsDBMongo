using ContactsDBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Dto
{
    public class PersonDto
    {
        public PersonDto(Person person, List<Phone> phones, List<Email> emails)
        {
            Name = person.Name;
            Id = person.Id;
            City = person.City;
            Notes = person.Notes;
            Phones = phones;
            Emails = emails;
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public string City { get; set; }

        public string Notes { get; set; }

        public List<Phone> Phones { get; set; }

        public List<Email> Emails { get; set; }

    }
}
