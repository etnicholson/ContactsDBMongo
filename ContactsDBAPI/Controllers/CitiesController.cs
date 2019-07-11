using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsDBAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IPersonRepository _person;

        public CitiesController(IPersonRepository person)
        {
            _person = person;
        }

        [HttpGet("cities")]
        public async Task<IActionResult> Cities()
        {
            var cities = await _person.RetreiveCities();

            return Ok(cities);

        }
    }
}