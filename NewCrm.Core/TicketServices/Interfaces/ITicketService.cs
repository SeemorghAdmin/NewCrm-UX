using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Entities.Ticketing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.TicketServices.Interfaces
{
   public interface ITicketService
    {
        //اینترفیس مربوط به اضافه کردن تیکت ها
        Task<int> AddTicket(Ticket ticket);
       //اینترفیس مبوط به اضافه کردن چت ها
        Task<bool> AddTicketingChat(TicketingChat ticket);
        //خواندن اطلاعات از جدول مربوطه همراه با توکن
        Task<IEnumerable<Ticket>> GetTicket(string id);
        //خواندن اطلاعات از جدول مربوطه همراه با توکن
        Task<IEnumerable<Ticket>> GetDiactiveTicket(string id);
       //ویرایش اطلاعاط از جدول مربوطه
        Task<bool> PutDiactiveTcket(int id);
        //خواندن اطلاعات از جدول مربوطه همراه با توکن
        Task<IEnumerable<Ticket>> GetAllTickets(string id);
        //ویرایش و ثبت آخرین فردی که در تیکت ها چت میکند
        Task<bool> PutResiver(int id, ChatTicketingViewModel user);
        //ویرایش اطلاعاط از جدول مربوطه
        Task<IEnumerable<Ticket>> GetOwnerTicket(string id);
        //ویرایش اطلاعاط از جدول مربوطه
        Task<int> CountMessage(string userId);
        //ویرایش اطلاعاط از جدول مربوطه
        Task<int> CountTicket(string userId);
    }
}
