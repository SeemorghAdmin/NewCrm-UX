using System;
using System.Collections.Generic;
using System.Text;
using NewCrm.Core.Services.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using NewCrm.Core.DTOs;
using NewCrm.Core.Security;
using NewCrm.Core.Convertors;

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

            return person.PersonNational_ID;
        }

        public async Task<bool> IsExistEmail(string email)
        {
            return await _context.People.AnyAsync(a => a.Email == email);
        }

        public async Task<bool> IsExistNationalId(string nationalId)
        {
            return await _context.People.AnyAsync(a => a.PersonNational_ID == nationalId);
        }

        public async Task<bool> IsExistUserName(string userName)
        {
            return await _context.People.AnyAsync(a => a.UserName == userName);
        }

        public async Task<Person> Login(LoginViewModel login)
        {
            string hashPassword = PasswordHasher.ComputeSha256Hash(login.Password);

            return await _context.People.SingleOrDefaultAsync(a => a.UserName == login.UserName && a.Password == hashPassword);
        }

        public async Task<IEnumerable<Person>> People()
        {
            return await _context.People.ToListAsync();
        }
    }
}
