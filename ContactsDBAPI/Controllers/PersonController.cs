using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsDBAPI.Dto;
using ContactsDBAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPhoneRepository _phone;
        private readonly IPersonRepository _person;
        private readonly IEmailRepository _email;

        public PersonController(IPhoneRepository phone, IPersonRepository person, IEmailRepository email)
        {
            _phone = phone;
            _email = email;
            _person = person;
        }


        [HttpPost("findbyphone")]
        public async Task<IActionResult> FindByPhone([FromBody] string phone)
        {

            var exist = await _phone.PhoneExist(phone);

            if (!exist)
            {
                return BadRequest("Phone not found");
            }


            var person = new PersonDto();





            return Ok(person);

        }


    }
}