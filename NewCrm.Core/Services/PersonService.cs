using System;
using System.Collections.Generic;
using System.Text;
using NewCrm.Core.Services.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace NewCrm.Core.Services
{
    public class PersonService : IPersonService
    {
        private NewCrmContext _context;

        public PersonService(NewCrmContext context)
        {
            _context = context;
        }
        public async Task<string> AddPerson(Person person)
        {
            await _context.People.AddAsync(person);

            await _context.SaveChangesAsync();

            return person.PersonNationalId;
        }

        public async Task<bool> IsExistEmail(string email)
        {
            return await _context.People.AnyAsync(a => a.Email == email);
        }

        public async Task<bool> IsExistNationalId(string nationalId)
        {
            return await _context.People.AnyAsync(a => a.PersonNationalId == nationalId);
        }

        public async Task<bool> IsExistUserName(string userName)
        {
            return await _context.People.AnyAsync(a => a.UserName == userName);
        }
    }
}
