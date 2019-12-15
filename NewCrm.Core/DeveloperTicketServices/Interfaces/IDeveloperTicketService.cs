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
        Task<int> AddTicket(DeveloperTicket ticket);
        Task<bool> AddTicketingChat(DeveloperTicketChat ticket);
        Task<IEnumerable<DeveloperTicket>> GetTicket(string id);
        Task<IEnumerable<DeveloperTicket>> GetTicketForOwnerManager(string id);
        Task<IEnumerable<DeveloperTicketChat>> GetDeveloperTicketChat(int id, string userId);
        Task<bool> AddComment(DeveloperTicketChat  developerTicketChat);
        Task<bool> PutResiverDeveloper(int id, DeveloperTicketigViewModel user);
        Task<bool> PutSeen(int id,string userId);
    }
}
