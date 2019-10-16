﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewCrm.Core.Services.Interfaces;
using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Entities.User;
using NewCrm.Core.Security;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private IStaffService _staffService;
        private IPersonService _personService;

        public StaffController(IPersonService personService, IStaffService staffService)
        {
            _staffService = staffService;
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> PostStaff(RegisterStaffViewModel model)
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
                PersonNationalId = model.PersonNationalId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                FatherName = model.FatherName,
                Gender = model.Gender,
                UserName = model.UserName,
                ShenasNum = model.ShenasNum,
                ShenasSerial = model.ShenasSerial,
                NationalCardSerial = model.NationalCardSerial,
                BirthDate = new DateTime(model.BirthDate),
                CreateTime = DateTime.Now,
                LastEditTime = DateTime.Now,
                IsActive = false,
                Password = PasswordHasher.ComputeSha256Hash($"{model.UserName}seemsys{model.Password}")
            };

            Staff staff = new Staff()
            {
                Address = model.Address,
                EduDegree = model.EduDegree,
                EduField = model.EduField,
                PersonNationalId = await _personService.AddPerson(person),
                PositionId = model.PositionId,
                StaffNumber = model.StaffNumber,
                TeleNumber = model.TeleNumber
            };

            return await _staffService.AddStaff(staff);
        }
    }
}