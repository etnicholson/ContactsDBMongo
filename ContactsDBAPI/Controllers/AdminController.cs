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
    public class AdminController : ControllerBase
    {
        private readonly ILogRepository _log;
        private readonly IPersonRepository _person;
        private readonly IPhoneRepository _phone;

        public AdminController(ILogRepository log, IPhoneRepository phone, IPersonRepository person )
        {
            _log = log;
            _person = person;
            _phone = phone;
        }

        [HttpGet("isadmin")]
        public ActionResult<bool> IsAdmin()
        {
            var admin = false;
            var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;

            if (userEmail == "admin@admin.com") admin = true;

            return Ok(admin);

        }

        [HttpGet("csv")]
        public async Task<ActionResult<CSVPhonesDto>> CSV()
        {


            var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;

            if (userEmail != "admin@admin.com")
            {
                return BadRequest("Not an admin");
            }

            var phones = await _phone.GetAllNumbers();

            var result = new List<CSVPhonesDto>();

            foreach (var item in phones)
            {
                var temp = new CSVPhonesDto();
                temp.Name = item.Name;
                temp.Phone = item.Number;
                result.Add(temp);
            }




            return Ok(result);

        }

    }
}