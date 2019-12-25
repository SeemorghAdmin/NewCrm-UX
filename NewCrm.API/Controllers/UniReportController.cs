using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewCrm.Core.Services;
using NewCrm.Core.Services.Interfaces;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniReportController : ControllerBase
    {
        // ایجاد شی از سروریس گزارش دانشگاه ها
        private readonly IUniReport _service;

        // مقدار دهی سرویس گزارش دانشگاه ها
        public UniReportController(IUniReport service)
        {
            _service = service;
        }

        [HttpPost]
        public string Test()
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;

            return _service.Test(userId);
        }
    }
}