using NewCrm.DataLayer.Entities.Ticketing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.TicketServices.Interfaces
{
   public interface IserviceType
    {
        //اینترفیس مربوط به اضافه کردن نوع سرویس
        Task<bool> AddServiceType(ServiceType ticketServiceType);
    }
}
