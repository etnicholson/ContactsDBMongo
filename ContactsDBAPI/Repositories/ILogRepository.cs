using ContactsDBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Repositories
{
    public interface ILogRepository
    {
        Task Create(string owner, string phone, string email, string action);

        Task<List<Log>> RetriveLogs();
        Task<Log> RetriveByOwner(string owner);
        Task<Log> RetriveByEmail(string email);
        Task<Log> RetriveByPhone(string email);

    }
}
