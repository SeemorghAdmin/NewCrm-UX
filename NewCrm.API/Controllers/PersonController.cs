using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewCrm.Core.DTOs;
using NewCrm.Core.Services.Interfaces;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

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

                return Ok(user.Role1);
            }

            return BadRequest("کاربری با این مشخصات یافت نشد");
        }
    }
}