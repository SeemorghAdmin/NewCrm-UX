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
        //ثبت پیام های ارسالی بین کاربران با سطوح مختلف در جدول
        public async Task<bool> AddComment(TicketingChat ticketingChat)
        {
            await _context.TicketingChats.AddAsync(ticketingChat);
            await _context.SaveChangesAsync();
            return true;
        }   
       //نمایش پیام های مربوط به یک تیکت بر اساس اینکه کاربر مشتری باشد یا مدیر فنی
        public async Task<IEnumerable<TicketingChat>> GetTicketingChat(int id,string userId)
        {
            var user = await _context.People.SingleOrDefaultAsync(r => r.PersonNational_ID == userId);
            if (user.Role1 == 3)
            {
                var ticket = (from a in _context.TicketingChats.Include(a => a.Ticket)
                                    .Include(a => a.Person)
                                    where a.Ticket_ID == id && a.Confidential == false
                                    select new TicketingChat
                                    {
                                        TicketingChat_ID = a.TicketingChat_ID,
                                        Ticket_ID = a.Ticket_ID,
                                        Comment = a.Comment,
                                        CommentTime = ConvertDate.ConvertSha(Convert.ToDateTime(a.CommentTime)),
                                        PersonNational_ID = a.PersonNational_ID,
                                        Confidential = a.Confidential,
                                        Ticket = a.Ticket,
                                        Person = a.Person
                                    }).ToList();
                return ticket;
            }
            else
            {
                var ticket = await (from a in _context.TicketingChats.Include(a => a.Ticket)
                                     .Include(a => a.Person)
                                    where a.Ticket_ID == id
                                    select new TicketingChat
                                    {
                                        TicketingChat_ID = a.TicketingChat_ID,
                                        Ticket_ID = a.Ticket_ID,
                                        Comment = a.Comment,
                                        CommentTime = ConvertDate.ConvertSha(Convert.ToDateTime(a.CommentTime)),
                                        PersonNational_ID = a.PersonNational_ID,
                                        Confidential = a.Confidential,
                                        Ticket = a.Ticket,
                                        Person = a.Person

                                    }).ToListAsync();
                return ticket;
            }
        }
        //تغییر وضعیت پیام خوانده نشده به پیام خوانده شده
        public async Task<bool> PutSeen(int id,string userId)
        {          
             List<TicketingChat> a = await _context.TicketingChats.Where(b => b.Ticket_ID == id && b.Resiver == userId ).ToListAsync();
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
