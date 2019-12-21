using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewCrm.Core.Services.Interfaces;
using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Entities.User;
using NewCrm.Core.Security;
using NewCrm.Core.Convertors;
using NewCrm.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using NewCrm.Core.Generators;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private IStaffService _staffService;
        private IPersonService _personService;
        private NewCrmContext _context;
        private readonly AppSettings _appSettings;

        public StaffController(IPersonService personService, IStaffService staffService, NewCrmContext context, IOptions<AppSettings> appSettings)
        {
            _staffService = staffService;
            _personService = personService;
            _context = context;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> PostStaff(RegisterStaffViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("لطفاً فیلد های مشخص شده را تکمیل نمایید");
            }
            if (await _personService.IsExistUserName(model.UserName))
            {
                return BadRequest("نام کاربری تکراری میباشد");
            }

            if (await _personService.IsExistNationalId(model.PersonNationalId))
            {
                return BadRequest("شماره ملی تکراری میباشد");
            }

            if (await _personService.IsExistEmail(model.Email))
            {
                return BadRequest("ایمیل وارد شده قبلا ثبت شده است");
            }

            Person person = new Person()
            {
                PersonNational_ID = model.PersonNationalId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = FixedText.FixedEmail(model.Email),
                FatherName = model.FatherName,
                Gender = model.Gender,
                UserName = model.UserName,
                ShenasNum = model.ShenasNum,
                ShenasSerial = model.ShenasSerial,
                NationalCardSerial = model.NationalCardSerial,
                BirthDate = new DateTime(model.BirthDate, 1, 1),
                CreateTime = DateTime.Now,
                LastEditTime = DateTime.Now,
                IsActive = true,
                NeedChangePassword = true,
                Password = PasswordHasher.ComputeSha256Hash($"{model.UserName}seemsys123456")
            };

            person.Role1 = 2;
            if (model.IsAdmin == true)
            {
                person.Role2 = 1;
            }
            else
            {
                person.Role2 = 2;
            }

            Staff staff = new Staff()
            {
                Address = model.Address,
                EduDegree = model.EduDegree,
                EduField = model.EduField,
                PersonNational_ID = await _personService.AddPerson(person),
                PositionId = model.PositionId,
                StaffNumber = model.StaffNumber,
                TeleNumber = model.TeleNumber
            };


            return await _staffService.AddStaff(staff);
        }

        [HttpPost]
        [Route("LandingPagePerson")]
        public async Task<ActionResult<Person>> PostLandingPageStaff(LandingPageViewModel model)
        {
            if (await _personService.IsExistNationalId(model.Id))
            {
                Person a = await _context.People.SingleOrDefaultAsync(r => r.PersonNational_ID == model.Id);
                a.Email = model.Email;
                a.FirstName = model.Fname;
                a.LastName = model.Lname;
                a.PersonNational_ID = model.Id;
                _context.Entry(a).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                //ارسال توکن به مرورگر کاربر
                Person user = await _context.People.SingleOrDefaultAsync(r => r.PersonNational_ID == model.Id);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("seemsys", model.Id)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                user.Password = null;
                return user;
            }
            else
            {
                Person person = new Person()
                {
                    PersonNational_ID = model.Id,
                    FirstName = model.Fname,
                    LastName = model.Lname,
                    Email = FixedText.FixedEmail(model.Email),
                    FatherName = null,
                    Gender = false,
                    UserName = FixedText.FixedEmail(model.Email),
                    ShenasNum = null,
                    ShenasSerial = null,
                    NationalCardSerial = null,
                    CreateTime = DateTime.Now,
                    LastEditTime = DateTime.Now,
                    IsActive = true,
                    NeedChangePassword = false,
                    Password = PasswordHasher.ComputeSha256Hash($"seemsys123456")
                };

                if (model.type == "Customer")
                {
                    person.Role1 = 3;
                }
                else if (model.type == "")
                {
                    person.Role1 = 2;
                    person.Role2 = 1;
                }
                else
                {
                    person.Role1 = 2;
                    person.Role2 = 2;
                }
                Staff staff = new Staff()
                {
                    Address = null,
                    EduDegree = null,
                    EduField = null,
                    PersonNational_ID = await _personService.AddPerson(person),
                    PositionId = null,
                    StaffNumber = model.Id,
                    TeleNumber = null
                };
                await _staffService.AddStaff(staff);
                //ارسال توکن به مرورگر کاربر
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("seemsys", model.Id)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                person.Token = tokenHandler.WriteToken(token);
                person.Password = null;
                return person;
            }
        }
        [HttpGet]
        public async Task<IEnumerable<Staff>> GetStaff()
        {
            return await _staffService.People();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutStaff(int id, RegisterStaffViewModel staff)
        {
            if (id.ToString() != staff.PersonNationalId)
            {
                return BadRequest();
            }

            try
            {
                await _staffService.PutStaff(id, staff);
                return Ok(true);
            }
            catch (Exception)
            {
                return NotFound(false);
            }
        }
    }
}