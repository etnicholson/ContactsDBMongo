using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsDBAPI.Models;
using ContactsDBAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //    [Authorize]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository _log;


        public LogController(ILogRepository log)
        {
            _log = log;
        }

        [HttpGet("getlogs")]
        public async Task<ActionResult<List<Log>>> GetLogs()
        {
            return Ok(await _log.RetriveLogs());

        }


    }
}