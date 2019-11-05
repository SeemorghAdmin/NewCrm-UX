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
        private IDeveloperService _developerService;
        private IPersonService _personService;

        public DeveloperController(IPersonService personService, IDeveloperService developerService)
        {
            _developerService = developerService;
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> PostStaff(DeveloperViwModel model)
        {
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
                IsActive = false,
                Password = PasswordHasher.ComputeSha256Hash($"{model.UserName}seemsys{model.Password}")
            };

            Developer developer = new Developer()
            {
                MobileNumber = model.MobileNumber,
                CreateTime = DateTime.Now,
                LastEditTime = DateTime.Now,
                PersonNational_ID = await _personService.AddPerson(person),


            };


            return await _developerService.AddDeveloper(developer);

        }


    }
}