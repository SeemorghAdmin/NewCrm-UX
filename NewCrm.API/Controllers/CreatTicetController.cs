using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewCrm.Core.DTOs;
using NewCrm.Core.TicketServices.Interfaces;
using NewCrm.DataLayer.Entities.Ticketing;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatTicetController : ControllerBase
    {
        private ITicketService  _ticketService;
        private IgetService _getService;
        public CreatTicetController(ITicketService ticketService,IgetService igetService)
        {
            _ticketService = ticketService;
            _getService = igetService;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> PostAddTicketingChat(CreatTicketViewModel model)
        {


            Ticket ticket = new Ticket()
            {
                Service_ID = model.Services_ID,
                Title = model.Title,
                PersonNational_ID = model.PersonNational_ID,
                DateOfCreation = DateTime.Now.ToString(),
                Active = true,
                Closure = DateTime.Now.ToString(),
                Status = model.Status,
            };

            TicketingChat  ticketingChat= new  TicketingChat()
            {
                Ticket_ID = await _ticketService.AddTicket(ticket),
                Comment = model.Comment,
                CommentTime = DateTime.Now.ToString(),
                PersonNational_ID = model.PersonNational_ID,
                Confidential = false,
             
            };
            return await _ticketService.AddTicketingChat(ticketingChat);
        }

        [HttpGet("{id}")]
        public IEnumerable<DataLayer.Entities.Ticketing.Services> GetServiceType(int id)
        {
            return _getService.GetServiceAsync(id);
        }
       [HttpPut("{id}")]      
        public async Task<bool> PutDiactiveTicket(int id)
        {
            return await _ticketService.PutDiactiveTcket(id);

        }
    }
}