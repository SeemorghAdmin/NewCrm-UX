using NewCrm.Core.TicketServices.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.Ticketing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NewCrm.Core.Convertors;
using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Entities.User;

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

        public async Task<IEnumerable<Ticket>> GetAllTickets(string id)
        {
            var tickets = await (from a in _context.Tickets.Include(a => a.Services)
                             .Include(a => a.Person)
                                 where a.Resiver == id
                                 select new Ticket
                                 {
                                     Ticket_ID = a.Ticket_ID,
                                     Service_ID = a.Service_ID,
                                     Title = a.Title,
                                     PersonNational_ID = a.PersonNational_ID,
                                     DateOfCreation = ConvertDate.ConvertSha(Convert.ToDateTime(a.DateOfCreation)),
                                     Active = a.Active,
                                     Status = a.Status,
                                     Services = a.Services,
                                     Person = a.Person,
                                     UnseenNumber = _context.TicketingChats.Where(s => s.Ticket_ID == a.Ticket_ID && s.Seen == false).Count()
                                }).OrderByDescending(o => o.DateOfCreation).ToListAsync();

            return tickets;
        }

        public async Task<IEnumerable<Ticket>> GetDiactiveTicket(string id)
        {
            var ticket = await (from a in _context.Tickets.Include(a => a.Services)
                              .Include(a => a.Person)
                                where a.Active == false && a.PersonNational_ID == id
                               select new Ticket
                               {
                                   Ticket_ID = a.Ticket_ID,
                                   Service_ID = a.Service_ID,
                                   Title = a.Title,
                                   PersonNational_ID = a.PersonNational_ID,
                                   DateOfCreation = ConvertDate.ConvertSha(Convert.ToDateTime(a.DateOfCreation)),
                                   Active = a.Active,
                                   Status = a.Status,
                                   Services = a.Services,
                                   Person = a.Person
                               }).ToListAsync();
            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetOwnerTicket(string id)
        {
            var ticket = await (from a in _context.Tickets.Include(a => a.Services)
                             .Include(a => a.Person)
                                where a.Active == false && a.Resiver == id
                                select new Ticket
                                {
                                    Ticket_ID = a.Ticket_ID,
                                    Service_ID = a.Service_ID,
                                    Title = a.Title,
                                    PersonNational_ID = a.PersonNational_ID,
                                    DateOfCreation = ConvertDate.ConvertSha(Convert.ToDateTime(a.DateOfCreation)),
                                    Active = a.Active,
                                    Status = a.Status,
                                    Services = a.Services,
                                    Person = a.Person
                                }).ToListAsync();
            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetTicket(string id)
        {
           
            var ticket = await (from a in _context.Tickets.Include(a => a.Services)
                              .Include(a => a.Person)
                                where a.Active == true && a.PersonNational_ID == id
                                select new Ticket
                                {
                                    Ticket_ID = a.Ticket_ID,
                                    Service_ID = a.Service_ID,
                                    Title = a.Title,
                                    PersonNational_ID = a.PersonNational_ID,
                                    DateOfCreation = ConvertDate.ConvertSha(Convert.ToDateTime(a.DateOfCreation)),
                                    Active = a.Active,
                                    Status = a.Status,
                                    Services = a.Services,
                                    Person = a.Person
                                }).OrderByDescending(o => o.Ticket_ID).ToListAsync(); 
            return ticket;
        }

       

        public async Task<bool> PutDiactiveTcket(int id)
        {
            Ticket a =await _context.Tickets.FindAsync(id);
            if(a.Active == true)
            {
                a.Active = false;
                _context.Entry(a).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            else
                a.Active = true;
            _context.Entry(a).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PutResiver(int id, ChatTicketingViewModel user)
        {
            Ticket a = await _context.Tickets.SingleOrDefaultAsync(r => r.Ticket_ID == id);
            Person s = await _context.People.SingleOrDefaultAsync(y =>y.PersonNational_ID == user.Resiver);
            if(s.Role1==3)
            {
                return true;
            }
            else
            {
                a.Resiver = user.Resiver;
            }

            _context.Entry(a).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
