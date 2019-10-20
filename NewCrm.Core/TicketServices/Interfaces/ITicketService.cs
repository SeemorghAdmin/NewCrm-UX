using NewCrm.DataLayer.Entities.Ticketing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.TicketServices.Interfaces
{
   public interface ITicketService
    {
        Task<int> AddTicket(Ticket ticket);
        Task<bool> AddTicketingChat(TicketingChat ticket);
    }
}
