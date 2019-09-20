using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ContactsDBAPI.Dto;
using ContactsDBAPI.Models;
using ContactsDBAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;

namespace ContactsDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository _log;


        public LogController(ILogRepository log)
        {
            _log = log;
        }

        [HttpGet("getlogs/{page}")]
        public async Task<ActionResult<IEnumerable<Log>>> GetLogs(int page)
        {
            var l =  await _log.RetriveLogs();
            var final = l.AsQueryable<Log>().OrderByDescending(p => p.Date);
            var result =  PagingList.Create<Log>(final, 20, page);


            if (result.Count == 0) return Ok("End of Logs");

            return Ok(result);

        }


        [HttpGet("getlogsbyphone/{phone}")]
        public async Task<ActionResult<IEnumerable<Log>>> getLogsByPhone(string phone)
        {
             var l = await _log.RetriveLogs();
            phone =  Regex.Replace(phone, @"^(\+)|\D", "$1");
            var final = l.AsQueryable<Log>().Where(p=> p.Phone == phone).OrderByDescending(p => p.Date);
            return Ok(final);

        }

        [HttpGet("getlogsbyemail/{email}")]
        public async Task<ActionResult<IEnumerable<Log>>> getLogsByEmail(string email)
        {
            var l = await _log.RetriveLogs();
            var final = l.AsQueryable<Log>().Where(p => p.Email == email).OrderByDescending(p => p.Date);
            return Ok(final);

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