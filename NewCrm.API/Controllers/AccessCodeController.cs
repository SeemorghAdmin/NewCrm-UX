using Microsoft.AspNetCore.Mvc;
using NewCrm.Core.DTOs;
using NewCrm.Core.Services.Interfaces;
using NewCrm.DataLayer.Entities.User;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet]
        [Route("getaccessmodifier")]
        public async Task<IEnumerable<AccessModifier>> GetAccesModifier()
        {
            return await _service.GetAccessModifier();
        }
    }
}
