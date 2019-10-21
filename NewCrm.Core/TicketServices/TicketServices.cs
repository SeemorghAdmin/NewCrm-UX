using NewCrm.Core.TicketServices.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.Ticketing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

            return ticket.Ticket_ID;
        }

        public async Task<bool> AddTicketingChat(TicketingChat ticket)
        {
            await  _context.TicketingChats.AddAsync(ticket);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Ticket>> GetTicket()
        {
            var ticket = await (from a in _context.Tickets.Include(a => a.Services)
                              .Include(a => a.Person)
                             
                              select new Ticket
                              {
                                 Ticket_ID=a.Ticket_ID,
                                  Service_ID=a.Service_ID,
                                  Title=a.Title,
                                  PersonNational_ID=a.PersonNational_ID,
                                  DateOfCreation=a.DateOfCreation,
                                  Active=a.Active,
                                  Status=a.Status,
                                  Services=a.Services,
                                  Person=a.Person
                              }).ToListAsync();


            return ticket;
        }
    }
}
