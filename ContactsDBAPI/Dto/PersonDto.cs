using ContactsDBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Dto
{
    public class PersonDto
    {

        public string Name { get; set; }

        public string City { get; set; }

        public string Notes { get; set; }

        public List<Phone> Phones { get; set; }

        public List<Email> Emails { get; set; }

    }
}
