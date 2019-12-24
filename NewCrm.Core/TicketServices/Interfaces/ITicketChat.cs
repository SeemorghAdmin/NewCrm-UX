using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Entities.Ticketing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.TicketServices.Interfaces
{
  public interface ITicketChat
    {
        //اینترفیس مربوط به خواندن اطلاعات 
        Task<IEnumerable<TicketingChat>> GetTicketingChat(int id,string userId);
        //اینترفیس مربوط به اظافه کردن چت ها
        Task<bool> AddComment(TicketingChat  ticketingChat);
        //اینترفیس مربوط به ویرایش  پیام های خوانده نشده
        Task<bool> PutSeen(int id,string userId);
    }
}
