using NewCrm.Core.TicketServices.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.Ticketing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NewCrm.Core.TicketServices
{
  public  class GetService : IgetService
    {
        private NewCrmContext _context;

        public GetService(NewCrmContext context)
        {
            _context = context;
        }
        //خواندن سویس ها از جدول دیتابیس
        public IEnumerable<DataLayer.Entities.Ticketing.Services> GetServiceAsync(int id)
        {
            var service = from a in _context.Services
                          where a.ServiceType_ID == id
                          select a;
            var serviceList = service.ToList();
            return serviceList;
        }
    }
}
