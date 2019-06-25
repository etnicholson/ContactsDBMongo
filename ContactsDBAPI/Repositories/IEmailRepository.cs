using ContactsDBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Repositories
{
    public interface IEmailRepository
    {
        Task<Email> CreateEmail(string personID, string email);

        Task<Email> FindEmail(string email);

        Task<Email> DeleteEmail(string email);

        Task<bool> EmailExist(string email);
    }
}
