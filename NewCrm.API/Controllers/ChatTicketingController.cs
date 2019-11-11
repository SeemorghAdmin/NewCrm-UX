using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCrm.Core.DTOs;
using NewCrm.Core.TicketServices.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.Ticketing;
using NewCrm.DataLayer.Entities.User;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatTicketingController : ControllerBase
    {
        private NewCrmContext _context;
        private ITicketChat  _ticketChat;
        public ChatTicketingController(ITicketChat ticketService, NewCrmContext context)
        {
            _ticketChat = ticketService;
            _context = context;
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
            Person s = await _context.People.SingleOrDefaultAsync(y => y.Role1 == 2 && y.Role2 == 1);
            if (model.Resiver == "" || model.Resiver == null)
            {
                u = s.PersonNational_ID;
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