using NewCrm.Core.TicketServices.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.Ticketing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.TicketServices
{

  
    public class TicketServices : ITicketService
    {
        private NewCrmContext _context;

        public TicketServices(NewCrmContext context)
        {
            _context = context;
        }
        public async Task<int> AddTicket(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);

            await _context.SaveChangesAsync();

            return ticket.TicketID;
        }

        public async Task<bool> AddTicketingChat(TicketingChat ticket)
        {
            await  _context.TicketingChats.AddAsync(ticket);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
