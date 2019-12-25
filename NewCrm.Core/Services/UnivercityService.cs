using NewCrm.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using NewCrm.DataLayer.Entities.EC;
using Microsoft.EntityFrameworkCore;
using NewCrm.Core.DTOs;

namespace NewCrm.Core.Services
{
    public class UnivercityService : IUnivercityService
    {
        private nernContext _context;

        public UnivercityService(nernContext nernContext)
        {
            _context = nernContext;
        }

        public async Task<bool> Delete(long id)
        {
            var uni = await _context.University.SingleOrDefaultAsync(a => a.UniNationalId == id);
            uni.Active = false;
            _context.Entry(uni).State = EntityState.Modified;

            var person = await _context.PersonalInfo.SingleOrDefaultAsync(a => a.Username == id.ToString());
            person.Active = false;
            _context.Entry(person).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteServiceForm(int id)
        {
            var service = await _context.ServiceFormRequest.SingleOrDefaultAsync(a => a.Id == (long)id);

            service.Active = false;
            _context.Entry(service).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return true;
        }


        //در دیتابیس از جدول یونیورسیتی سه مقدار بخش، نوع و وضعیت هر دانشگاه را می خواند و به انگولار می فرستد.
        //Angular = report subs
        public async Task<IEnumerable<object>> GetAllUniversity()
        {
            var query = from u in _context.University
                        select new
                        {
                            u.TypeVal,  
                            u.UniStatus,
                            u.UniSubCode
                           
                        }; 
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
    }
}
