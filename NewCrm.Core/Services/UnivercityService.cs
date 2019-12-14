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

        public async Task<IEnumerable<object>> GetAllUniversity()
        {
            var query = from u in _context.University
                        select new
                        {
                            u.TypeVal,
                            u.UniStatus,
                            u.UniSubStatus
                        };
            return query;
        }
        
        public async Task<IEnumerable<ServiceFormViewModel>> GetServiceForm()
        {
            var query = await (from s in _context.ServiceFormRequest
                               join u in _context.University on s.UniId equals u.UniNationalId
                               select new ServiceFormViewModel
                               {
                                   Id = s.Id,
                                   UniName = u.UniName,
                                   Status = s.StatusVal.ToString(),
                                   Number = s.ServiceFormContractNo,
                                   Time = s.ServiceFormContractDate.ToString()
                               }).ToListAsync();
            return query;
        }
    }
}
