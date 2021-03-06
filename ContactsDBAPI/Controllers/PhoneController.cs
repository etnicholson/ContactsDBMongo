﻿using System;
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
    public class PhoneController : ControllerBase
    {
            
        private readonly IPhoneRepository _phone;
        private readonly ILogRepository _log;
        private readonly IPersonRepository _person;

        public PhoneController(IPhoneRepository phone, ILogRepository log, IPersonRepository person)
        {
            _phone = phone;
            _log = log;
            _person = person;
        }


        [HttpPost("createphone")]
        public async Task<ActionResult<Phone>> CreatePhone([FromBody] CreatePhoneDto number)
        {
            var exist = await _phone.PhoneExist(number.Number);

            if (exist)
            {
                return BadRequest("Phone already on the database");
            }

            var phoneToReturn = await _phone.CreatePhone(number.PersonID, number.Number,number.Name);
            var person = await _person.FindPerson(number.PersonID);

            var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;

            await _log.Create(userEmail, number.Number, "", $"PHONE Created - {person.Name} ");


            return Ok(phoneToReturn);
        }


        [HttpPost("deletephone/{number}")]
        public async Task<IActionResult> DeletePhone(string number)
        {
            var exist = await _phone.PhoneExist(number);


            if (!exist)
            {
                return BadRequest("Phone not on the database");
            }

            var phoneFound = await _phone.FindPhone(number);
            var person = await _person.FindPerson(phoneFound.PersonID);
            await _phone.DeletePhone(number);
            var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;

            await _log.Create(userEmail, number, "", $"PHONE DELETED - {person.Name} ");


            return Ok();
        }

    }
}