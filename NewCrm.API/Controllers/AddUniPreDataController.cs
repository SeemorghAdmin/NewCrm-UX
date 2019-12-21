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
        // GET: api/AddUniPreData
        [HttpGet]
        public async Task<IEnumerable<object>> GetPreUiData()
        {
            return await _service.GetUniPreData();
        }


        // POST: api/AddUniPreData
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AddUniPreData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
