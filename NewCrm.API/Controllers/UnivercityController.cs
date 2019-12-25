using Microsoft.AspNetCore.Mvc;
using NewCrm.Core.DTOs;
using NewCrm.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnivercityController : ControllerBase
    {
        // ایجاد شی از سرویس دانشگاهها
        private readonly IUnivercityService _service;
        //مقدار دهی شی سرویس دانشگاه در کانستراکتور
        public UnivercityController(IUnivercityService service)
        {
            _service = service;
        }

        [HttpPost]
        //post
        // api/univercity/5
        // حذف دانشگاه
        public async Task<ActionResult<bool>> Delete(long id)
        {
            // ارسال ای دی دانشگاه به سرویس
            return await _service.Delete(id);
        }

        [HttpGet]
        //get api/univercity
        // ارسال دانشگاه ها به سمت کلاینت
        public async Task<IEnumerable<ServiceFormViewModel>> GetAll()
        {
            return await _service.GetServiceForm();
        }

        [HttpDelete]
        //delete api/univercity/5
        //حذف سرویس فرم دانشگاه
        public async Task<ActionResult<bool>> DeleteServiceForm(int id)
        {
            // ارسال ای دی به سرویس 
            return await _service.DeleteServiceForm(id);
        }




        [HttpGet]
        [Route("ReportSubs")]
        public async Task<IEnumerable<object>> GetUni()
        {
            return await _service.GetAllUniversity();
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutUni(UniversityViewModel model)
        {
            return await _service.PutUni(model);
        }
    }
}