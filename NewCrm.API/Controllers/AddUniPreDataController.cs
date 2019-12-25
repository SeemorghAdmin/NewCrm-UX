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
    public class AddUniPreDataController : ControllerBase
    {
        private readonly IUniPreData _service;
        public AddUniPreDataController(IUniPreData uniPreData)
        {
            _service = uniPreData;
        }


        //در جدول دوم که پایین صفحه نمایش داده می شود، اطلاعات توسط این قسمت از دیتابیس خوانده می شوند.
        // GET: api/AddUniPreData
        [HttpGet]
        public async Task<IEnumerable<object>> GetPreUiData()
        {
            return await _service.GetUniPreData();
        }

        //بالای صفحه برای ثبت دانشگاه در دیتابیس به پست نیاز است.
        // در صورتی که کد دانشگاه تکراری باشد پیغام خطا ارسال می شود.
        // POST: api/AddUniPreData
        [HttpPost]
        public async Task<ActionResult<bool>> Post(UniPreData uniPreData)
        {
            if (await _service.IsExistNational(uniPreData.Unicode))
            {
                return BadRequest("کد دانشگاه تکراری است.");
            }
            await _service.AddUniInfo(uniPreData);
            return true;
        }

        // PUT: api/AddUniPreData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        public void Delete(int id)
        {
        }
    }
}

