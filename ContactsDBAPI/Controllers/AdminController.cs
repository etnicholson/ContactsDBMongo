using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AdminController(ILogRepository log)
        {
            _log = log;
        }

        [HttpGet("isadmin")]
        public ActionResult<bool> IsAdmin()
        {
            var admin = false;
            var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;

            if (userEmail == "admin@admin.com") admin = true;

            return Ok(admin);

        }
    }
}