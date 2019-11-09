using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IEnumerable<DataLayer.Entities.Ticketing.TicketingChat>> GetTicketChat(int id)
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            return await _ticketChat.GetTicketingChat(id,userId);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> PostAddTicketingChat(ChatTicketingViewModel model)
        {
            bool t;
            string u;
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            if(model.Resiver == "" || model.Resiver == null)
            {
                u = "4180109123";
            }
            else
            {
                u = model.Resiver;
            }
            if(model.Conf == 1)
            {
                t = true;
            }
            else
            {
                t = false;
            }
            TicketingChat ticketingChat = new TicketingChat()
            {
                Ticket_ID = model.Ticket_ID,
                Comment = model.Comment,
                CommentTime = DateTime.Now.ToString(),
                PersonNational_ID = userId,
                Sender = userId,
                Resiver = u,
                Confidential = t
            };
            return await _ticketChat.AddComment(ticketingChat);
        }
        [HttpPut("{id}")]
        public async Task<bool> PutSeen(int id)
        {
            return await _ticketChat.PutSeen(id);
        }
    }
}