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
    public class UnivercityController : ControllerBase
    {
        private readonly IUnivercityService _service;
       
        public UnivercityController(IUnivercityService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Delete( long id)
        {
            return await _service.Delete(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceFormViewModel>> GetAll()
        {
            return await _service.GetServiceForm();
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteServiceForm(int id)
        {
            return await _service.DeleteServiceForm(id);
        }




        [HttpGet]
        [Route("ReportSubs")]
       public async Task<IEnumerable<object>> GetUni()
        {
            return await _service.GetAllUniversity();
        }
    }
}