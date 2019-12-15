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
using NewCrm.DataLayer.Entities.Upload;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceFileUploadController : ControllerBase
    {
        private nernContext _contextt;
        private NewCrmContext _context;
        public ServiceFileUploadController(NewCrmContext context,nernContext nernContext)
        {
            _contextt = nernContext;
            _context = context;
        }
        string gc;
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload3()
        {
            try
            {
                var file = Request.Form.Files[0];
                //////به دست آوردن مقادیری که به فایل اضافه کردیم با استفاده از حلقه ///////
                foreach (string key in Request.Form.Keys)
                {
                    if (key == "type")
                    {
                        gc = Request.Form[key];
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

                      
                        if (gc == "post-reciept")
                        {
                            ServiceFormRequest serviceFormRequest = _contextt.ServiceFormRequest.SingleOrDefault(s => s.Id == 56);
                            serviceFormRequest.PostReceipt = bytes;
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











        /////////دانلود فایل ذخیره شده در دیتابیس//////////////
        [HttpGet]
        public FileResult DownloadFile(int? fileId)
        {
            ServiceFileUpload entities = new ServiceFileUpload();
            var file = _context.ServiceFileUploads.ToList().Find(p => p.Id == fileId.Value);
            return File(file.Data, file.ContentType, file.Name);
        }
    }
}