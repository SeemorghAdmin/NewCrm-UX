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
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NewCrm.Core.Services
{
    public class PersonService : IPersonService
    {
        // ایجاد شی دیتاکانتکس
        private readonly NewCrmContext _context;
        private readonly AppSettings _appSettings;
        // مقدار دهی شی دیتاکانتکس در دیتابیس

        public PersonService(NewCrmContext context, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }
        // اضافه کردن پرسن در دیتابیس
        public async Task<string> AddPerson(Person person)
        {
            // اضافه کردن پرسن در دیتابیس
            await _context.People.AddAsync(person);
            // ذخیره سازی دیتابیس

            await _context.SaveChangesAsync();
            // بازگشت دادن ای دی پرسن
            return person.PersonNational_ID;
        }
        // چک کردن یونیک بودن ایمیل
        public async Task<bool> IsExistEmail(string email)
        {
            return await _context.People.AnyAsync(a => a.Email == email);
        }
        // چک کردن یونیک بودن کدملی
        public async Task<bool> IsExistNationalId(string nationalId)
        {
            return await _context.People.AnyAsync(a => a.PersonNational_ID == nationalId);
        }
        // چک کردن یونیک بودن نام کاربری
        public async Task<bool> IsExistUserName(string userName)
        {
            return await _context.People.AnyAsync(a => a.UserName == userName);
        }
        // لاگین کاربر
        public async Task<Person> Login(LoginViewModel login)
        {
            // هش کردن پسورد کاربر
            string hashPassword = PasswordHasher.ComputeSha256Hash($"{login.UserName}seemsys{login.Password}");
            // پیدا کردن کاربر بر اساس نام کاربری و پسورد هش شده
            var user = await _context.People.SingleOrDefaultAsync(a => a.UserName == login.UserName && a.Password == hashPassword);
            // چک کردن موجود بودن کاربر در صورت وجود
            if (user != null)
            {
                // ساخت تو کن jwt
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler(); //jwt ایجاد شی 
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);// گرفتن کلید خارجی از اپ ستینگ
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("seemsys", user.PersonNational_ID)// ایجاد توکن بر اساس کلید داخلی و ایجاد توکن ای دی
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),// زمان معتبر بودن توکن
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                // ساخت نوکن
                var token = tokenHandler.CreateToken(tokenDescriptor);
                // قرار دادن توکن در یوزر
                user.Token = tokenHandler.WriteToken(token);

                // remove password before returning
                // نال کردن پسورد برای ارسال نشدن به سمت کلاینت
                user.Password = null;
            }
            // ارسال یوزر
            return user;
        }

        public async Task<IEnumerable<Person>> People()
        {
            var person = await (from a in _context.People
                                where( (a.Role1 == 2 && a.Role2 == 2 ) || (a.Role1 ==2 && a.Role2==1))                             
                                select a).ToListAsync();
            return person;
        }
        // متد تغیر پسورد
        public async Task<bool> ChangePassword(string personNationalId, ChangePassword changePassword)
        {
            // پیدا کردن یوزر بر اساس ای دی
            var user = await _context.People.FindAsync(personNationalId);
            // هش کردن پسورد قبلی 
            changePassword.OldPassword = PasswordHasher.ComputeSha256Hash($"{user.UserName}seemsys{changePassword.OldPassword}");
            // چک کردن درست بودن پسورد
            if (user.Password == changePassword.OldPassword)
            {
                // فالس کردن مقدار الزامی بودن تغیر پسورد
                user.NeedChangePassword = false;
                // قرار دادن پسورد جدید در یوزر و ذخیره دیتابیس
                user.Password = PasswordHasher.ComputeSha256Hash($"{user.UserName}seemsys{changePassword.Password}");
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        // ارسال پروفایل کاربر
        public async Task<Person> UserProfile(string userId)
        {
            // پیدا کردن یوزر بر اساس ای دی 
            return await _context.People.FindAsync(userId);
        }

        public async Task<IEnumerable<Person>> PeopleDeveloper()
        {
            var person = await(from a in _context.People
                               where (a.Role1 ==1   || (a.Role1 == 2 && a.Role2 == 1) ) 
                               select a).ToListAsync();
            return person;
        }
    }
}
