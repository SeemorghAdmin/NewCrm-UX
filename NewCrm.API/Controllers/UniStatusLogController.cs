using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCrm.Core.DTOs;
using NewCrm.Core.UniversityService.Interfaces;
using NewCrm.DataLayer.Entities.EC;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniStatusLogController : ControllerBase
    {
        private nernContext _contextt;
        private IUniversity _university;
        public UniStatusLogController(IUniversity university,nernContext nernContext)
        {
            _university = university;
            _contextt = nernContext;
        }
        string ga;
        [HttpPost]
        public async Task<ActionResult<bool>> Post(UniStatusLogViewModel model)
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;       
            return await _university.UpdateUniversity(model,userId);
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public IActionResult Upload3()
        {
            try
            {
                var file = Request.Form.Files[0];
                //////به دست آوردن مقادیری که به فایل اضافه کردیم با استفاده از حلقه ///////
                foreach (string key in Request.Form.Keys)
                {
                    if (key == "id")
                    {
                        ga = Request.Form[key];
                    }
                }
                ////////////ایجاد یک مونه کپی از فایل ارسالی در پوشه////
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    ///////خواندن فایل کپی شده در فولدر مورد نظر و تبدیل آن به فت بایت و ذخیره در جدول دیتابیس////////
                    byte[] bytes;
                    using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        bytes = new byte[stream.Length];
                        stream.Read(bytes, 0, Convert.ToInt32(stream.Length));
                        long u = Convert.ToInt64(ga.ToString());
                        University university = _contextt.University.SingleOrDefault(s => s.UniNationalId ==u);
                        university.SubscriptionExampleForm = bytes;
                        _contextt.Entry(university).State = EntityState.Modified;
                        _contextt.SaveChanges();
                    }
                    ////////در آخر پاک کردن فایل مورد نظر از پوشه//////////
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception  ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


    }
}