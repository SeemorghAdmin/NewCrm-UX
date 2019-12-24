using NewCrm.Core.TicketServices.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.Ticketing;
using NewCrm.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.TicketServices
{
    public class ServiceTypeService : IserviceType
    {
        private NewCrmContext _context;

        public ServiceTypeService(NewCrmContext context)
        {
            _context = context;
        }
        //اضافه کردن نوع سرویس به جدول دیتابیس
        public async Task<bool> AddServiceType(ServiceType ticketServiceType)
        {
          await _context.ServiceTypes.AddAsync(ticketServiceType);
          await  _context.SaveChangesAsync();
          return true;            
        }
    }
}
