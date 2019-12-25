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
        // ایجاد شی از استف سرویس و پرسن سرویس
        private IStaffService _staffService;
        private IPersonService _personService;
        private NewCrmContext _context;
        // فراخوانی اپ ستینگ برای کلید خارجی jwt
        private readonly AppSettings _appSettings;
        // مقدار دهی اشیا لازم در کانستراکتور
        public StaffController(IPersonService personService, IStaffService staffService, NewCrmContext context, IOptions<AppSettings> appSettings)
        {
            _staffService = staffService;
            _personService = personService;
            _context = context;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        //post 
        // api/staff
        public async Task<ActionResult<bool>> PostStaff(RegisterStaffViewModel model)
        {
            // چک کردن معتبر بودن مدل
            if (!ModelState.IsValid)
            {
                // ارسال خطا
                return BadRequest("لطفاً فیلد های مشخص شده را تکمیل نمایید");
            }
            // چک کردن یونیک بودن نام کاربری
            if (await _personService.IsExistUserName(model.UserName))
            {
                // ارسال خطای تکراری بودن نام کاربری در صورت یونیک نبودن
                return BadRequest("نام کاربری تکراری میباشد");
            }
            // چک کردن یونیک بودن شماره ملی
            if (await _personService.IsExistNationalId(model.PersonNationalId))
            {
                // ارسال خطا در صورت تکراری بودن شماره ملی
                return BadRequest("شماره ملی تکراری میباشد");
            }
            // چک کردن یونیک بودن ایمیل
            if (await _personService.IsExistEmail(model.Email))
            {
                // ارسال خطا در صورت یونیک نبودن ایمیل کاربر
                return BadRequest("ایمیل وارد شده قبلا ثبت شده است");
            }
            // ایجاد شی از پرسن
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
            // قرار دادن رول 2 برای کاربران خاشع
            person.Role1 = 2;

            //  اگر مقدار ادمین خاشع برابر ترو باشد 
            if (model.IsAdmin == true)
            {
                // رول کاربر برابر یک میشود
                person.Role2 = 1;
            }
            else
            {
                person.Role2 = 2;
            }
            // ایجاد شی جدید از اسف
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

            // ارسال استف به سرویس و متد اد اسف برای ذخیره سازی
            return await _staffService.AddStaff(staff);
        }

        [HttpPost]
        [Route("LandingPagePerson")]
        public async Task<ActionResult<Person>> PostLandingPageStaff(LandingPageViewModel model)
        {
            //ایجاد یک شرط برای چک کردن اینکه اطلاعات کاربر داخل دیابیس وجود دارد یا خیر
            if (await _personService.IsExistNationalId(model.Id))
            {
                //در صورت وجود اطلاعات فرد را به دست می اوریم
                Person a = await _context.People.SingleOrDefaultAsync(r => r.PersonNational_ID == model.Id);
                a.Email = model.Email;
                a.FirstName = model.Fname;
                a.LastName = model.Lname;
                a.PersonNational_ID = model.Id;
                //اطلاعات فرد درصورت بروز تغییرات ویرایش می شود
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
                //اگر اطلاعات فرد مورد نظر در دخل دیتابیس وجود نداشت عملیات درج اطلاعات در دیتابیس آغاز می شود
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
                    Password = PasswordHasher.ComputeSha256Hash($"{FixedText.FixedEmail(model.Email)}seemsys123456")
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
                if(model.type == "Customer")
                {
                    await _personService.AddPerson(person);
                }
                else
                { 
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
                }
               
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
        // ارسال کاربران خاشع
        // api/staff
        public async Task<IEnumerable<Staff>> GetStaff()
        {
            // ارسال کل کاربران خاشع
            return await _staffService.People();
        }

        [HttpPut("{id}")]
        //ویرایش استف
        // api.staff/5
        public async Task<ActionResult<bool>> PutStaff(int id, RegisterStaffViewModel staff)
        {
            try
            {
                // ارسال استف به به سرویس و متد پوت استف
                await _staffService.PutStaff(id, staff);
                // ارسال اوکی در صورت موفقیت امیز بودن
                return Ok(true);
            }
            catch (Exception ex)
            {
                // ارسال نات فوند در صورت خطا
                return NotFound(false);
            }
        }

        [HttpGet]
        [Route("geteditstaff")]
        // api/staff/geteditstaff
        public async Task<RegisterStaffViewModel> GetStaffEdit(string id)
        {
            // پیدا یوزر بر اساس ای دی
            return await _staffService.GetStaffEdit(id);
        }

        [HttpDelete("{id}")]
        // api/staff/5
        public async Task<bool> DeleteStaff(string id)
        {
            // حذف یوزر بر اساس ای دی
            return await _staffService.DeleteStaff(id);
        }
    }
}