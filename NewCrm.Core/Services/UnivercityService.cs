using NewCrm.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using NewCrm.DataLayer.Entities.EC;
using Microsoft.EntityFrameworkCore;
using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Context;

namespace NewCrm.Core.Services
{
    public class UnivercityService : IUnivercityService
    {
        // ایجاد شی از دیتا کانتکس
        private nernContext _context;
        // مقدار دهی دیتاکانتکس در کانستراکنور
        public UnivercityService(nernContext nernContext)
        {
            _context = nernContext;
        }
        // حذف دانشگاه
        public async Task<bool> Delete(long id)
        {
            // پیدا کردن دانشگاه
            var uni = await _context.University.SingleOrDefaultAsync(a => a.UniNationalId == id);
            // قرار دادن مقدار فالس در فیلد اکتیو
            uni.Active = false;
            _context.Entry(uni).State = EntityState.Modified;

            var person = await _context.PersonalInfo.SingleOrDefaultAsync(a => a.Username == id.ToString());
            person.Active = false;
            // اپدیت کردن در دیتا بیس
            _context.Entry(person).State = EntityState.Modified;
            // ذخیره تغیرات دیتا ببیس
            await _context.SaveChangesAsync();
            return true;
        }
        // حذف سرویس فرم
        public async Task<bool> DeleteServiceForm(int id)
        {
            // پیدا کردن سرویس فرم
            var service = await _context.ServiceFormRequest.SingleOrDefaultAsync(a => a.Id == (long)id);
            // قرار دادن مقدار فالس در فیلد اکتیو
            service.Active = false;
            _context.Entry(service).State = EntityState.Modified;
            // ذخیره تغیرات دیتا ببیس
            await _context.SaveChangesAsync();
            return true;
        }


        //در دیتابیس از جدول یونیورسیتی سه مقدار بخش، نوع و وضعیت هر دانشگاه را می خواند و به انگولار می فرستد.
        //Angular = report subs
        public async Task<IEnumerable<object>> GetAllUniversity()
        {
            var query = await (from u in _context.University
                               select new
                               {
                                   u.TypeVal,
                                   u.UniStatus,
                                   u.UniSubCode

                               }).ToListAsync(); 
            return query;
        }
        //-----------------------------------------------------

        
        public async Task<IEnumerable<ServiceFormViewModel>> GetServiceForm()  
        {
            var query = await (from s in _context.ServiceFormRequest
                               join u in _context.University on s.UniId equals u.UniNationalId
                               select new
                               {
                                   s.Id,
                                   u.UniName,
                                   s.StatusVal,
                                   s.ServiceFormContractNo,
                                   s.ServiceFormContractDate,

                                   //FormatContract = true,
                                   s.SignedForm,
                                   s.FinalSignedForm,
                                   s.Letter,
                                   s.PostReceipt,
                               }).ToListAsync();

            List<ServiceFormViewModel> list = new List<ServiceFormViewModel>();

            foreach (var item in query)
            {
                list.Add(new ServiceFormViewModel
                {
                    Id = item.Id,
                    UniName = item.UniName,
                    Status = item.StatusVal.ToString(),
                    Number = item.ServiceFormContractNo,
                    Time = item.ServiceFormContractDate.ToString(),
                    FormatContract = true,
                    SinglSignatureContract = (item.SignedForm != null) ? true : false,
                    FinalContract = (item.FinalSignedForm != null) ? true : false,
                    Letter = (item.Letter != null) ? true : false,
                    ReceiptPost = (item.PostReceipt != null) ? true : false
                });
            }

            return list;
        }
        // ویرایش دانشگاه
        public async Task<bool> PutUni(UniversityViewModel model)
        {
            // پیدا کردن دانشگاه براساس نشنال ایدی
            var uni = await _context.University.SingleOrDefaultAsync(a => a.UniNationalId == model.UniNationalId);
            // قرار دادن مقادیر جدید در شی یونیور سیتی
            uni.Address = model.UniAddress;
            uni.EcoCode = model.UniEcoCode;
            uni.FaxNo = model.AgentFaxNo;
            uni.PostalCode = model.UniPostalCode;
            uni.SignatoryName = model.AgentFname;
            uni.SignatoryNationalId = model.UniSignatoryNationalId;
            uni.SignatoryPos = model.UniSignatoryPos;
            uni.SiteAddress = model.UniWebsite;
            uni.TeleNo = model.UniTelNo;
            uni.TopManagerName = model.UniTopManagerName;
            uni.TopManagerPos = model.UniTopManagerPos;
            uni.UniName = model.UniName;
            uni.UniNationalId = model.UniNationalId;
            uni.UniPublicEmail = model.UniEmail;
            // اپدیت کردن یونیورسیتی در دیتابیس
            _context.Entry(uni).State = EntityState.Modified;
            // ذخیره تغیرات دیتابیس
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
