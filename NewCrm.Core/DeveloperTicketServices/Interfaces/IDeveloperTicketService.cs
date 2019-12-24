using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Entities.TicketForDeveloper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.DeveloperTicketServices.Interfaces
{
  public  interface IDeveloperTicketService
    {
        //اینترفیس مربوط به اضافه کردن تیکت های ارسالی از کارمندان خشع به برنامه نویسان
        Task<int> AddTicket(DeveloperTicket ticket);
        //اینترفیس مربوط به اضافه کردن چت هایی که در تیکت ها اتفاق می افتد
        Task<bool> AddTicketingChat(DeveloperTicketChat ticket);
        //خواندن تیکت ها از جدول دیتابیس
        Task<IEnumerable<DeveloperTicket>> GetTicket(string id);
        //خواندن تیکت ها از جدول دیتابیس
        Task<IEnumerable<DeveloperTicket>> GetTicketForOwnerManager(string id);
        //خواندن تیکت های هر فرد با توجه به ای دی آنها
        Task<IEnumerable<DeveloperTicketChat>> GetDeveloperTicketChat(int id, string userId);
        //اضافه کردن گفت و گو های جدیدی که در تیکت ها اتفاق می افتد
        Task<bool> AddComment(DeveloperTicketChat  developerTicketChat);
        //ویرایش و ثبت ای دی فردی که اخرین چت را انجام داده
        Task<bool> PutResiverDeveloper(int id, DeveloperTicketigViewModel user);
        //ویراش پیام های خوانده نشده به خوانده شده
        Task<bool> PutSeen(int id,string userId);
    }
}
