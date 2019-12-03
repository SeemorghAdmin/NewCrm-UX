using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCrm.Core.DeveloperTicketServices.Interfaces;
using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.TicketForDeveloper;
using NewCrm.DataLayer.Entities.User;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperTicketController : ControllerBase
    {
        private NewCrmContext _context;
        private IDeveloperTicketService _developerTicketService;
        public DeveloperTicketController(NewCrmContext context,IDeveloperTicketService iDeveloperTicketService)
        {
            _context = context;
            _developerTicketService = iDeveloperTicketService;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> PostAddTicketingChat(DeveloperTicketViewModel model)
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            Person s = await _context.People.SingleOrDefaultAsync(y => y.Role1 == 2 && y.Role2 == 1 && y.Role3 == 1 && y.Role4 == 1);
            DeveloperTicket ticket = new  DeveloperTicket()
            {
                PersonNational_ID = userId,
                DateOfCreation = DateTime.Now.ToString(),
                Active = true,
                Closure = DateTime.Now.ToString(),
                Status = model.Status,
                Resiver = s.PersonNational_ID
            };
            DeveloperTicketChat ticketingChat = new DeveloperTicketChat()
            {
                DeveloperTicket_ID = await _developerTicketService.AddTicket(ticket),
                Comment = model.Comment,
                CommentTime = DateTime.Now.ToString(),
                PersonNational_ID = userId,
                Confidential = false,
                Resiver = s.PersonNational_ID,
                Sender = userId,
            };
            return await _developerTicketService.AddTicketingChat(ticketingChat);
        }

        [HttpPost]
        [Route("AddDeveloperTicketChat")]
        public async Task<ActionResult<bool>> PostAddTicketingChat(DeveloperTicketigViewModel model)
        {
            bool t;
            string u;
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            if (model.Resiver == "" || model.Resiver == null)
            {
                Person s = await _context.People.SingleOrDefaultAsync(y => y.Role1 == 2 && y.Role2 == 1 && y.Role3 == 1 && y.Role4 == 1);
                u = s.PersonNational_ID;
            }
            else
            {
                u = model.Resiver;
            }
            if (model.Conf == 1)
            {
                t = true;
            }
            else
            {
                t = false;
            }
            DeveloperTicketChat ticketingChat = new DeveloperTicketChat()
            {
                DeveloperTicket_ID = model.DeveloperTicket_ID,
                Comment = model.Comment,
                CommentTime = DateTime.Now.ToString(),
                PersonNational_ID = userId,
                Sender = userId,
                Resiver = u,
                Confidential = t
            };
            return await _developerTicketService.AddComment(ticketingChat);
        }
        [HttpPut("{id}")]
        public async Task<bool> PutResiverIcket(int id, DeveloperTicketigViewModel user)
        {
            return await _developerTicketService.PutResiverDeveloper(id, user);
        }
        [Route("Putseen")]
        public async Task<bool> PutSeen(int id)
        {
            return await _developerTicketService.PutSeen(id);
        }
    }
}