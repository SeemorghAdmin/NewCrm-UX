using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewCrm.Core.DTOs;
using NewCrm.Core.TicketServices.Interfaces;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTicketController : ControllerBase
    {
        private ITicketService _ticketService;
        public GetTicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;          
        }

        [HttpGet]
        public async Task<IEnumerable<DataLayer.Entities.Ticketing.Ticket>> GetServiceType()
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            return await _ticketService.GetTicket(userId);
        }


        [HttpGet]
        [Route("DiactiveTicket")]
        public async Task<IEnumerable<DataLayer.Entities.Ticketing.Ticket>> GetDiactiveTicket()
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            return await _ticketService.GetDiactiveTicket(userId);
        }
        [HttpGet]
        [Route("AllTickets")]
        public async Task<IEnumerable<DataLayer.Entities.Ticketing.Ticket>> GetAllTickets()
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            return await _ticketService.GetAllTickets(userId);
        }

        [HttpGet]
        [Route("GetOwner")]
        public async Task<IEnumerable<DataLayer.Entities.Ticketing.Ticket>> GetOwnerTicket()
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            return await _ticketService.GetOwnerTicket(userId);
        }
        [HttpPut("{id}")]
        public async Task<bool> PutResiverIcket(int id ,ChatTicketingViewModel user)
        {          
            return await _ticketService.PutResiver(id,user);
        }

        [HttpGet]
        [Route("count")]
        public async Task<ActionResult<int>> GetCount()
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            
            return await _ticketService.CountMessage(userId); ;
        }
    }
}