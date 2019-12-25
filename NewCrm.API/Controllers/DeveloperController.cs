using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewCrm.Core.Convertors;
using NewCrm.Core.DTOs;
using NewCrm.Core.Security;
using NewCrm.Core.Services.Interfaces;
using NewCrm.DataLayer.Entities.User;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        // ایجاد  شی از سرویس دولوپر
        private IDeveloperService _developerService;
        // ایجاد شی از سرویس پرسن
        private IPersonService _personService;
        //مقدار دهی کردن سرویس ها در کانستراکتور
        public DeveloperController(IPersonService personService, IDeveloperService developerService)
        {
            _developerService = developerService;
            _personService = personService;
        }

        [HttpPost]
        // post
        // api/developer
        public async Task<ActionResult<bool>> PostStaff(DeveloperViwModel model)
        {
            // چک کردن یونیک بودن یوزر نام
            if (await _personService.IsExistUserName(model.UserName))
            {
                // ارسال بد ریکوست در صورت تکراری بودن نام کاربری
                return BadRequest("نام کاربری تکراری میباشد");
            }
            // چک کردن یونیک بودن شماره ملی
            if (await _personService.IsExistNationalId(model.PersonNationalId))
            {
                // ارسال بد ریکوست در صورت تکراری بودن شماره ملی
                return BadRequest("شماره ملی تکراری میباشد");
            }
            // چک کردن تکراری نبودن ایمیل
            if (await _personService.IsExistEmail(model.Email))
            {
                // ارسال بد ریکوست در صورت تکراری بودن ایمیل
                return BadRequest("ایمیل وارد شده قبلا ثبت شده است");
            }
            //ایجاد شی پرسن
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
                Password = PasswordHasher.ComputeSha256Hash($"{model.UserName}seemsys{model.Password}")
            };

            // ایجاد شی دولوپر
            Developer developer = new Developer()
            {
                MobileNumber = model.MobileNumber,
                CreateTime = DateTime.Now,
                LastEditTime = DateTime.Now,
                PersonNational_ID = await _personService.AddPerson(person),
            };

            // ارسال شی دولوپر به سروریس و متد دولوپر
            return await _developerService.AddDeveloper(developer);

        }


    }
}