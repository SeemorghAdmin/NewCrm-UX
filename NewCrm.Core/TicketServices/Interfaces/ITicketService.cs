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
        Task<int> AddTicket(Ticket ticket);
        Task<bool> AddTicketingChat(TicketingChat ticket);
        Task<IEnumerable<Ticket>> GetTicket(string id);
        Task<IEnumerable<Ticket>> GetDiactiveTicket(string id);
        Task<bool> PutDiactiveTcket(int id);
        Task<IEnumerable<Ticket>> GetAllTickets(string id);
        Task<bool> PutResiver(int id, ChatTicketingViewModel user);
        Task<IEnumerable<Ticket>> GetOwnerTicket(string id);
    }
}
