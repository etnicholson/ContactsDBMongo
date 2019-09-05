using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsDBAPI.Dto;
using ContactsDBAPI.Models;
using ContactsDBAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]


    public class EmailController : ControllerBase
    {

        private readonly IEmailRepository _email;
        private readonly ILogRepository _log;
        private readonly IPersonRepository _person;

        public EmailController(IEmailRepository email, ILogRepository log, IPersonRepository person)
        {
            _email = email;
            _log = log;
            _person = person;
        }


        [HttpPost("createemail")]
        public async Task<ActionResult<Email>> CreateEmail([FromBody] CreateEmailDto email)
        {
            var exist = await _email.EmailExist(email.Email);

            if (exist)
            {
                return BadRequest("Email already on the database");
            }

            var emailToReturn = await _email.CreateEmail(email.PersonID, email.Email);
            var person = await _person.FindPerson(email.PersonID);

            var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;

            await _log.Create(userEmail, "", email.Email, $"EMAIL CREATED - {person.Name} ");


            return Ok(emailToReturn);
        }


        [HttpPost("deleteEmail/{email}")]
        public async Task<IActionResult> DeletePhone(string email)
        {
            var exist = await _email.EmailExist(email);


            if (!exist)
            {
                return BadRequest("Email not on the database");
            }

            var emailFound = await _email.FindEmail(email);
            var person = await _person.FindPerson(emailFound.PersonID);
            await _email.DeleteEmail(email);
            var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;

            await _log.Create(userEmail, "", email, $"EMAIL DELETED - {person.Name} ");


            return Ok();
        }




    }
}