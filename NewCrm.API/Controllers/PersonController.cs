﻿using System;
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
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        // method login
        [HttpPost]
        public async Task<ActionResult<object>> Login(LoginViewModel login)
        {
            var user = await _service.Login(login);

            if (user != null)
            {
                if (user.IsActive == false)
                {
                    return BadRequest("حساب کاربری شما غیر فعال میباشد");
                }

                return Ok(new { user, StatusCode = 200});
            }

            return BadRequest("کاربری با این مشخصات یافت نشد");
        }

        [HttpGet]
        [Authorize]
        [Route("userprofile")]
        public IActionResult GetAll()
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;

            
            return Ok(userId);
        }

        [HttpPost]
        [Route("changepassword")]
        public async Task<ActionResult<bool>> ChangePassword(ChangePassword changePassword)
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;

            if (await _service.ChangePassword(userId, changePassword))
            {
                return Ok(true);
            }

            return BadRequest("خطای در انجام عملیات رخ داده است.");
        }
        
        [HttpGet]
        public async Task<IEnumerable<Person>> People()
        {
            return await _service.People();
        }

    }
}