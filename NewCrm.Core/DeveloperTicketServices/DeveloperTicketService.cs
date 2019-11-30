using NewCrm.Core.DeveloperTicketServices.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.TicketForDeveloper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewCrm.Core.Convertors;
using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Entities.User;

namespace NewCrm.Core.DeveloperTicketServices
{
    public class DeveloperTicketService : IDeveloperTicketService   
    {
        private NewCrmContext _context;
        public DeveloperTicketService(NewCrmContext context)
        {
            _context = context;
        }

        public async Task<bool> AddComment(DeveloperTicketChat developerTicketChat)
        {

            await _context.DeveloperTicketChats.AddAsync(developerTicketChat);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> AddTicket(DeveloperTicket ticket)
        {
            await _context.DeveloperTickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return ticket.DeveloperTicket_ID;
        }

        public async Task<bool> AddTicketingChat(DeveloperTicketChat ticket)
        {
            await _context.DeveloperTicketChats.AddAsync(ticket);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<DeveloperTicketChat>> GetDeveloperTicketChat(int id, string userId)
        {
            var user = await _context.People.SingleOrDefaultAsync(r => r.PersonNational_ID == userId);
            if (user.Role1 == 2 && user.Role2 == 2)
            {
                var ticket = (from a in _context.DeveloperTicketChats.Include(a => a.DeveloperTicket)
                                    .Include(a => a.Person)
                              where a.DeveloperTicket_ID == id && a.Confidential == false
                              select new DeveloperTicketChat
                              {
                                  DeveloperTicketChat_ID = a.DeveloperTicketChat_ID,
                                  DeveloperTicket_ID = a.DeveloperTicket_ID,
                                  Comment = a.Comment,
                                  CommentTime = ConvertDate.ConvertSha(Convert.ToDateTime(a.CommentTime)),
                                  PersonNational_ID = a.PersonNational_ID,
                                  Confidential = a.Confidential,
                                  DeveloperTicket = a.DeveloperTicket,
                                  Person = a.Person
                              }).ToList();
                return ticket;
            }
            else
            {
                var ticket = await(from a in _context.DeveloperTicketChats.Include(a => a.DeveloperTicket)
                                    .Include(a => a.Person)
                                   where a.DeveloperTicket_ID == id
                                   select new DeveloperTicketChat
                                   {
                                       DeveloperTicketChat_ID = a.DeveloperTicketChat_ID,
                                       DeveloperTicket_ID = a.DeveloperTicket_ID,
                                       Comment = a.Comment,
                                       CommentTime = ConvertDate.ConvertSha(Convert.ToDateTime(a.CommentTime)),
                                       PersonNational_ID = a.PersonNational_ID,
                                       Confidential = a.Confidential,
                                       DeveloperTicket = a.DeveloperTicket,
                                       Person = a.Person

                                   }).ToListAsync();
                return ticket;
            }
        }

        public async Task<IEnumerable<DeveloperTicket>> GetTicket(string id)
        {
            var ticket = await(from a in _context.DeveloperTickets
                           .Include(a => a.Person)
                               where a.Active == true && a.PersonNational_ID == id
                               select new DeveloperTicket
                               {
                                   DeveloperTicket_ID = a.DeveloperTicket_ID,
                                   PersonNational_ID = a.PersonNational_ID,
                                   DateOfCreation = ConvertDate.ConvertSha(Convert.ToDateTime(a.DateOfCreation)),
                                   Active = a.Active,
                                   Status = a.Status,
                                   Person = a.Person,
                                   UnseenNumber = _context.DeveloperTicketChats.Where(s => s.DeveloperTicket_ID == a.DeveloperTicket_ID && s.Seen == false && s.PersonNational_ID != id).Count()
                               }).OrderByDescending(o => o.DeveloperTicket_ID).ToListAsync();
            return ticket;
        }

        public async Task<IEnumerable<DeveloperTicket>> GetTicketForOwnerManager(string id)
        {
            var ticket = await (from a in _context.DeveloperTickets
                         .Include(a => a.Person)
                                where a.Active == true && a.Resiver ==id
                                select new DeveloperTicket
                                {
                                    DeveloperTicket_ID = a.DeveloperTicket_ID,
                                    PersonNational_ID = a.PersonNational_ID,
                                    DateOfCreation = ConvertDate.ConvertSha(Convert.ToDateTime(a.DateOfCreation)),
                                    Active = a.Active,
                                    Status = a.Status,
                                    Person = a.Person,
                                    UnseenNumber = _context.DeveloperTicketChats.Where(s => s.DeveloperTicket_ID == a.DeveloperTicket_ID && s.Seen == false && s.PersonNational_ID != id).Count()
                                }).OrderByDescending(o => o.DeveloperTicket_ID).ToListAsync();
            return ticket;
        }

        public async Task<bool> PutResiverDeveloper(int id, DeveloperTicketigViewModel user)
        {
            DeveloperTicket a = await _context.DeveloperTickets.SingleOrDefaultAsync(r => r.DeveloperTicket_ID == id);
            if (user.Resiver == "" || user.Resiver == null)
            {
                Person s = await _context.People.SingleOrDefaultAsync(y => y.Role1 == 2 && y.Role2 == 1 && y.Role3 == 1 && y.Role4 == 1);
                a.Resiver = s.PersonNational_ID;
            }
            else
            {
                a.Resiver = user.Resiver;
            }
            _context.Entry(a).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PutSeen(int id)
        {
            List<DeveloperTicketChat> a = await _context.DeveloperTicketChats.Where(b => b.DeveloperTicket_ID == id).ToListAsync();
            foreach (var item in a)
            {
                item.Seen = true;
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return true;
        }
    }
}
