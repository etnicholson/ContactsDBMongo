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
            var currentDay = DateTime.Now.DayOfWeek;
            int daysTillCurrentDay = currentDay - DayOfWeek.Monday;
            var current = DateTime.Now.AddDays(-daysTillCurrentDay);
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


        [HttpGet("getmostactive")]
        public async Task<ActionResult<List<LogsWeekDto>>> GetMostActive()
        {

            var logs = await _log.RetriveLogs();
            var currentDay = DateTime.Now.DayOfWeek;
            int daysTillCurrentDay = currentDay - DayOfWeek.Monday;
            var current = DateTime.Now.AddDays(-daysTillCurrentDay);
            var dic = new Dictionary<string, int>();
            var result = new List<LogsWeekDto>();

            for (int i = 0; i < 7; i++)
            {
                var logCount = logs.Where(p => p.Date.Date == current.Date).ToList();

                foreach (var item in logCount)
                {
                    if (dic.ContainsKey(item.Owner)) dic[item.Owner]++;
                    else dic.Add(item.Owner, 1);


                }


                current = current.AddDays(1);


            }


            foreach (var item in dic)
            {
                var temp = new LogsWeekDto(item.Key, item.Value);
                result.Add(temp);
            }

            return Ok(result);

        }



    }
}