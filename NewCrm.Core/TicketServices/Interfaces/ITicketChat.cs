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
        Task<IEnumerable<TicketingChat>> GetTicketingChat(int id,string userId);
        Task<bool> AddComment(TicketingChat  ticketingChat);
        Task<bool> PutSeen(int id,string userId);
    }
}
