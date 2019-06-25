using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Dto
{
    public class PersonRegisterDto
    {
        public string Name { get; set; }

        public string City { get; set; }

        public string Notes { get; set; }

        public List<string> Phones { get; set; }

        public List<string> Emails { get; set; }
    }
}
