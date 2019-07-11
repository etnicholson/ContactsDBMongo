using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Dto
{
    public class CreatePersonDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Notes { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }


    }
}
