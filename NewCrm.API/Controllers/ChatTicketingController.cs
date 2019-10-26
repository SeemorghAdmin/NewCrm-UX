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
    public class ChatTicketingController : ControllerBase
    {
        private ITicketChat  _ticketChat;
        public ChatTicketingController(ITicketChat ticketService)
        {
            _ticketChat = ticketService;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<DataLayer.Entities.Ticketing.TicketingChat>> GetTicketChat(int id)
        {
            return await _ticketChat.GetTicketingChat(id);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> PostAddTicketingChat(ChatTicketingViewModel model)
        {

            TicketingChat ticketingChat = new TicketingChat()
            {
                Ticket_ID = model.Ticket_ID,
                Comment = model.Comment,
                CommentTime = DateTime.Now.ToString(),
                PersonNational_ID = "16145828",
                Confidential = false
            };
            return await _ticketChat.AddComment(ticketingChat);
        }
    }
}