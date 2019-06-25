using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsDBAPI.Models;

namespace ContactsDBAPI.Repositories
{
    public class EmailRepository : IEmailRepository
    {

        public Task<Email> CreateEmail(string personID, string email)
        {
            throw new NotImplementedException();
        }

        public Task<Email> DeleteEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EmailExist(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Email> FindEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
