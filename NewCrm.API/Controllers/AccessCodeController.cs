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
        //ایجاد شی از سرویس اکسس کد
        private readonly IAccessCode _service;
        // مقدار دهی کردن شی اکسس کد 
        public AccessCodeController(IAccessCode service)
        {
            _service = service;
        }

        [HttpPost]
        //دریافت اکسس کد مختص به یک یوزر
        // post
        // api/accesscode
        public async Task<ActionResult<bool>> SetAccessCode(AccessCodeModel model)
        {
            return await _service.AddAccessCode(model);
        }

        [HttpGet]
        [Route("getaccessmodifier")]
        //ارسال اکسس کد های موجود در دیتا بیس 
        // get
        // api/accesscode/getaccessmodifier
        public async Task<IEnumerable<AccessModifier>> GetAccesModifier()
        {
            return await _service.GetAccessModifier();
        }
    }
}
