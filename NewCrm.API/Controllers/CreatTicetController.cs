using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCrm.Core.DTOs;
using NewCrm.Core.Services.Interfaces;
using NewCrm.Core.TicketServices.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.Ticketing;
using NewCrm.DataLayer.Entities.User;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatTicetController : ControllerBase
    {
        private NewCrmContext _context;

        private IPersonService _service;
        private ITicketService  _ticketService;
        private IgetService _getService;
        public CreatTicetController(ITicketService ticketService,IgetService igetService, IPersonService service , NewCrmContext context)
        {
            _ticketService = ticketService;
            _getService = igetService;
            _service = service;
            _context = context;
        }
        //درج اطلاعات یک تیکت جدید که توسط کاربر ایجاد شده و همچنین درج متن پیام در جدول تیکت چت
        [HttpPost]
        public async Task<ActionResult<bool>> PostAddTicketingChat(CreatTicketViewModel model)
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            Person s = await _context.People.SingleOrDefaultAsync(y => y.Role1 == 2 && y.Role2 == 1 && y.Role3 == 1 && y.Role4 == 1);
            Ticket ticket = new Ticket()
            {
                Service_ID = model.Services_ID,
                Title = model.Title,
                PersonNational_ID = userId,
                DateOfCreation = DateTime.Now.ToString(),
                Active = true,
                Closure = DateTime.Now.ToString(),
                Status = model.Status,
                Resiver = s.PersonNational_ID
            };
            TicketingChat ticketingChat = new TicketingChat()
            {
                Ticket_ID = await _ticketService.AddTicket(ticket),
                Comment = model.Comment,
                CommentTime = DateTime.Now.ToString(),
                PersonNational_ID = userId,
                Confidential = false,
                Resiver = s.PersonNational_ID,
                Sender = userId,
            };
            return await _ticketService.AddTicketingChat(ticketingChat);
        }
        //نمایش سرویس هایی که برای آنها پشتیبانی فنی ارایه مشود
        [HttpGet("{id}")]
        public IEnumerable<DataLayer.Entities.Ticketing.Services> GetServiceType(int id)
        {
            return _getService.GetServiceAsync(id);
        }
        //فعال سازی یا غیر فعال سازی تیکت ها 
       [HttpPut("{id}")]      
        public async Task<bool> PutDiactiveTicket(int id)
        {
            return await _ticketService.PutDiactiveTcket(id);

        }
    }
}