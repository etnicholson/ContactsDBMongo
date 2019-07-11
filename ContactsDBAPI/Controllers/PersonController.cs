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


        [HttpGet("findbyid/{id}")]
        public async Task<ActionResult<PersonDto>> FindById(string id)
        {

            var exist = await _person.PersonExist(id);

            if (!exist)
            {
                return BadRequest("Person not found");
            }


            var user = await _person.FindPerson(id);
            var personID = user.Id;
            var phoneList = await _phone.FindAllUserNumber(personID);
            var EmailList = await _email.FindAllUserEmails(personID);

            var person = new PersonDto(user, phoneList, EmailList);


            return Ok(person);

        }


        [HttpGet("findbyphone/{phone}")]
        public async Task<ActionResult<PersonDto>> FindByPhone(string phone)
        {

            var exist = await _phone.PhoneExist(phone);

            if (!exist)
            {
                return BadRequest("Phone not found");
            }

            Phone firstNumber = await _phone.FindPhone(phone);
            var personID = firstNumber.PersonID;

            var user = await _person.FindPerson(personID);
            var phoneList = await _phone.FindAllUserNumber(personID);
            var EmailList = await _email.FindAllUserEmails(personID);

            var person = new PersonDto(user, phoneList, EmailList);


            return Ok(person);

        }





        [HttpGet("findbyemail/{email}")]
        public async Task<IActionResult> FindByEmail(string email)
        {
            email = email.ToLower();
            var exist = await _email.EmailExist(email);

            if (!exist)
            {
                return BadRequest("Email not found");
            }

            Email firstEmail = await _email.FindEmail(email);
            var personID = firstEmail.PersonID;

            var user = await _person.FindPerson(personID);
            var phoneList = await _phone.FindAllUserNumber(personID);
            var EmailList = await _email.FindAllUserEmails(personID);

            var person = new PersonDto(user, phoneList, EmailList);

            return Ok(person);

        }


        [HttpPost("createperson")]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonDto p)
        {


                var existemail = await _email.EmailExist(p.Email);

                if (existemail)
                {
                    return BadRequest("Person's email already on the database");
                }

                var phoneValid = _phone.ValidPhone(p.Phone);
                if (!phoneValid)
                {
                return BadRequest("Invalid Phone number");

                }
            var existphone = await _phone.PhoneExist(p.Phone);

                if (existphone)
                {
                    return BadRequest("Person's number already on the database");
                }





            var person = await _person.CreatePerson(p.Name, p.City, p.Notes);


                await _email.CreateEmail(person.Id, p.Email);


 
                await _phone.CreatePhone(person.Id, p.Phone);

            



            return Ok(person.Id);

        }


        [HttpPost("deleteperson")]
        public async Task<IActionResult> DeletePerson([FromBody] string id)
        {
            var exist = await _person.PersonExist(id);


            if (!exist)
            {
                return BadRequest("Person not on the database");
            }




            await _person.DeletePerson(id);

            var phoneList = await _phone.FindAllUserNumber(id);
            var emailList = await _email.FindAllUserEmails(id);

            foreach (var item in phoneList)
            {
                await _phone.DeletePhone(item.Number);
            }

            foreach (var item in emailList)
            {
                await _email.DeleteEmail(item.UserEmail);
            }





            return Ok();

        }









    }
}