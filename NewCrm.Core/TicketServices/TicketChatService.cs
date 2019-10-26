using Microsoft.EntityFrameworkCore;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.Ticketing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using NewCrm.Core.TicketServices.Interfaces;
using NewCrm.Core.Convertors;
using NewCrm.Core.DTOs;

namespace NewCrm.Core.TicketServices
{
   public class TicketChatService : ITicketChat
    {
        private NewCrmContext _context;

        public TicketChatService(NewCrmContext context)
        {
            _context = context;
        }

      

        public async Task<bool> AddComment(TicketingChat ticketingChat)
        {
            await _context.TicketingChats.AddAsync(ticketingChat);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TicketingChat>> GetTicketingChat(int id)
        {
            var ticket = await(from a in _context.TicketingChats.Include(a => a.Ticket)
                                 .Include(a => a.Person)
                               where a.Ticket_ID ==id
                                select new TicketingChat
                                {
                                    TicketingChat_ID=a.TicketingChat_ID,
                                    Ticket_ID=a.Ticket_ID,
                                    Comment=a.Comment,
                                    CommentTime= ConvertDate.ConvertSha(Convert.ToDateTime(a.CommentTime)),
                                    PersonNational_ID=a.PersonNational_ID,
                                    Confidential=a.Confidential,
                                    Ticket=a.Ticket,
                                    Person=a.Person

                                }).ToListAsync();
            return ticket;
        }
    }
}
