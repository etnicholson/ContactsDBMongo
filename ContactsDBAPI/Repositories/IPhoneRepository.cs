using ContactsDBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDBAPI.Repositories
{
    public interface IPhoneRepository
    {
        Task<Phone> CreatePhone(string personID, string phone, string name);

        Task<Phone> FindPhone(string phone);

        Task<List<Phone>> FindAllUserNumber(string id);

        Task<List<Phone>> GetAllNumbers();

        Task DeletePhone(string phone);

        Task<bool> PhoneExist(string phone);

        bool ValidPhone(string phone);
    }
}
