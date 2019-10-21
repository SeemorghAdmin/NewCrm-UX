using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return await _ticketService.GetTicket();
        }
    }
}