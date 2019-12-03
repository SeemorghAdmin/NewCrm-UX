using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewCrm.Core.Services.Interfaces;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnivercityController : ControllerBase
    {
        private readonly IUnivercityService _service;

        public UnivercityController(IUnivercityService service)
        {
            _service = service;
        }

        [HttpPost]
        public bool Delete( int id)
        {
            return _service.Delete(id);
        }

        [HttpGet]
        public IEnumerable<object> GetAll()
        {
            return _service.GetServiceForm();
        }
    }
}