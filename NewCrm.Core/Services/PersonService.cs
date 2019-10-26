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
using NewCrm.Core.Generators;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace NewCrm.Core.Services
{
    public class PersonService : IPersonService
    {
        private NewCrmContext _context;
        private readonly AppSettings _appSettings;

        public PersonService(NewCrmContext context, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
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
            string hashPassword = PasswordHasher.ComputeSha256Hash($"{login.UserName}seemsys{login.Password}");

            var user = await _context.People.SingleOrDefaultAsync(a => a.UserName == login.UserName && a.Password == hashPassword);

            if (user != null)
            {
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("seemsys", user.PersonNational_ID)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                // remove password before returning
                user.Password = null;
            }
            
            return user;
        }

        public async Task<IEnumerable<Person>> People()
        {
            return await _context.People.ToListAsync();
        }
    }
}
