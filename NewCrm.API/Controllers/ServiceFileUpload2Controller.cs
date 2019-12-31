using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.EC;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceFileUpload2Controller : ControllerBase
    {
        private nernContext _contextt;
        public ServiceFileUpload2Controller(nernContext nernContext)
        {
            _contextt = nernContext;
        }
        string ga;
        string s;
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload1()
        {
            try
            {
                var file = Request.Form.Files[0];
                //////به دست آوردن مقادیری که به فایل اضافه کردیم با استفاده از حلقه ///////
                foreach (string key in Request.Form.Keys)
                {
                    if (key == "type")
                    {
                        ga = Request.Form[key];
                    }
                    if (key == "uNumber")
                    {
                        s = Request.Form[key];
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
                        int u = Convert.ToInt32(s.ToString());
                        if (ga == "final-signed-form")
                        {
                            ServiceFormRequest serviceFormRequest = _contextt.ServiceFormRequest.SingleOrDefault(s => s.Id == u);
                            serviceFormRequest.FinalSignedForm = bytes;
                            serviceFormRequest.StatusVal = 3000;
                            _contextt.Entry(serviceFormRequest).State = EntityState.Modified;
                            _contextt.SaveChanges();
                        }
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
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }

}