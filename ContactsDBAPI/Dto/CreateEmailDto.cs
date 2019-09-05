using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Dto
{
    public class CreateEmailDto
    {
        public string PersonID { get; set; }
        public string Email { get; set; }
    }
}
