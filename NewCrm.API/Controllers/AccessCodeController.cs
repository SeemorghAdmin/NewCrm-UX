using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewCrm.Core.DTOs;
using NewCrm.Core.Services.Interfaces;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessCodeController : ControllerBase
    {
        private readonly IAccessCode _service;

        public AccessCodeController(IAccessCode service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> SetAccessCode(AccessCodeModel model)
        {
            return await _service.AddAccessCode(model);
        }
    }
}
