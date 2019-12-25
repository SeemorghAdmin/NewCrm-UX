using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewCrm.Core.DTOs;
using NewCrm.Core.Services.Interfaces;
using NewCrm.DataLayer.Entities.User;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // ایجاد شی از پرسن سرویس
        private readonly IPersonService _service;

        // مقدار دهی شی پرسن سرویس در کانستراکتور
        public PersonController(IPersonService service)
        {
            _service = service;
        }

        // method login
        [HttpPost]
        // post
        // api/person
        // متد لاگین یوزر
        public async Task<ActionResult<object>> Login(LoginViewModel login)
        {
            // پیدا کردن یوزر
            var user = await _service.Login(login);
            // چک کردن وجود داشتن کاربر
            if (user != null)
            {
                // چک کردن فعال بودن کاربر
                if (user.IsActive == false)
                {
                    // اگر حساب کاربری غیر فعال باشد اعلان خطا
                    return BadRequest("حساب کاربری شما غیر فعال میباشد");
                }
                // بازگشت دادن یوزر در صورت درست بودن همه چی
                return Ok(new { user, StatusCode = 200});
            }
            // بازگشت دادن خطا در صورت اشتباه بودن نام کاربری یا رمز
            return BadRequest("کاربری با این مشخصات یافت نشد");
        }

        [HttpGet]
        [Authorize]
        [Route("userprofile")]
        //get
        // api/person/userprofile
        public async Task<ActionResult<Person>> GetAll()
        {
            //استخراج ای دی کاربر از توکن
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            // پیدا کردن یوزر بر اساس ای دی کاربر
            var user = await _service.UserProfile(userId);
            user.Password = null;
            return Ok(user);
        }

        [HttpPost]
        [Authorize]
        [Route("changepassword")]
        //post
        // api/person/changepassword
        // تغیر پسورد کاربر
        public async Task<ActionResult<bool>> ChangePassword(ChangePassword changePassword)
        {
            // استخراج ای دی کاربر
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            // چک کردن مخالف نبودن ای دی ارسالی و ای دی توکن استخراج شده
            // که بین راه داده ها دستکاری نشده باشند
            if (changePassword.UserId != userId)
            {
                return BadRequest("خطای در انجام عملیات رخ داده است.");
            }
            // تغییر پسورد کاربر با استفاده از متد changepassword در سروریس
            bool change = await _service.ChangePassword(userId, changePassword);
            // چک کردن تکمیل عملیات تغییر پسورد
            if (change)
            {
                return Ok(true);
            }

            return BadRequest("خطای در انجام عملیات رخ داده است.");
        }
        
        [HttpGet]
        [Route("getPersonAll")]
        public async Task<IEnumerable<Person>> People()
        {
            return await _service.People();
        }
        [HttpGet]
        [Route("getDeveloperPerson")]
        public async Task<IEnumerable<Person>> DeveloperPeople()
        {
            return await _service.PeopleDeveloper();
        }

    }
}