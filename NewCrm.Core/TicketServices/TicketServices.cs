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
        //ثبت یک تیکت جدید توسط کاربر
        public async Task<int> AddTicket(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);

            await _context.SaveChangesAsync();

            return ticket.Ticket_ID;
        }
        //ثبت پیام های رد و بدل شده توسط کاربران با سطوح مختلف 
        public async Task<bool> AddTicketingChat(TicketingChat ticket)
        {
            await  _context.TicketingChats.AddAsync(ticket);

            await _context.SaveChangesAsync();

            return true;
        }
        //به دست آوردن تعداد پیام های خوانده نشده
        public async Task<int> CountMessage(string userId)
        {
            return await _context.TicketingChats.Where(a => a.Resiver == userId && a.Seen == false).CountAsync();
        }
        //به دست آوردن تعداد تیکت های ارسالی به مدیر فنی یا پشتیبان
        public async Task<int> CountTicket(string userId)
        {
            return await _context.Tickets.Where(a => a.Resiver == userId).CountAsync();
        }
        //مشاهده تیکت ها توسط مدیر فنی یا پشتیبان
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
                                     UnseenNumber = _context.TicketingChats.Where(s => s.Ticket_ID == a.Ticket_ID && s.Seen == false && s.PersonNational_ID != id).Count()
                                }).OrderByDescending(o => o.Ticket_ID).ToListAsync();

            return tickets;
        }
        //مشاهده مشتریان بر درخواست های ارسال شده و غیر فعال خود
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
        //مشاهده مدیر فنی یا پشتیبان بر تیکت های غیر فعال 
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
        //مشاهده مشتریان بر تیکت های ارسالی و فعال خود
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
        //فعال سازی یا غیر فعال سازی تیکت ها توسط این متد انجام میشود
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
        //ویرایش و ثبت آیدی فردی که آخرین پیام برای او ارسال میشود
        public async Task<bool> PutResiver(int id, ChatTicketingViewModel user)
        {
            Ticket a = await _context.Tickets.SingleOrDefaultAsync(r => r.Ticket_ID == id);
            if (user.Resiver == "" || user.Resiver == null)
            {
                Person s = await _context.People.SingleOrDefaultAsync(y => y.Role1 == 2 && y.Role2 == 1 && y.Role3 == 1 && y.Role4 == 1);
                a.Resiver =  s.PersonNational_ID;
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
