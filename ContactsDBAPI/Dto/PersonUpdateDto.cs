using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Dto
{
    public class PersonUpdateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

    }
}
