using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Dto
{
    public class LogsWeekDto
    {
        public LogsWeekDto(string day, int logsNumbers)
        {
            Name = day;
            Value = logsNumbers;
        }

        public string Name { get; set; }

        public int Value { get; set; }
    }
}
