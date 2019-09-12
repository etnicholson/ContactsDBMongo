using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsDBAPI.Dto;
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

        [HttpGet("getlogsweek")]
        public async Task<ActionResult<List<LogsWeekDto>>> GetLogsWeek()
        {

            var logs = await _log.RetriveLogs();
            var today = DateTime.Now.Date; // This can be any date.
            var day = (int)today.DayOfWeek; //Number of the day in week. (0 - Sunday, 1 - Monday... and so On)
            //const int totalDaysOfWeek = 7; // Number of days in a week stays constant.
            var current = today.AddDays(day - 6).Date;
            var result = new List<LogsWeekDto>();
            for (int i = 0; i < 7; i++)
            {
                var logCount = logs.Where(p => p.Date.Date == current.Date).ToList();
                var temp = new LogsWeekDto(current.DayOfWeek.ToString(), logCount.Count);
                result.Add(temp);
                current = current.AddDays(1);


            }

            return Ok(result);

        }



    }
}