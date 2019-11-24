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
        //مشاهده مشتریان بر تیکت های فعال ثبت شده ی خود
        [HttpGet]
        public async Task<IEnumerable<DataLayer.Entities.Ticketing.Ticket>> GetTicket() 
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            return await _ticketService.GetTicket(userId);
        }

        //مشاهده مشتریان بر تیکت های غیر فعال ثبت شده ی خود
        [HttpGet]
        [Route("DiactiveTicket")]
        public async Task<IEnumerable<DataLayer.Entities.Ticketing.Ticket>> GetDiactiveTicket()    
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            return await _ticketService.GetDiactiveTicket(userId);
        }
        //مشاهده مدیر فنی و پشتیبان ها بر تیکت های فعال که برای آنها ارسال میشود
        [HttpGet]
        [Route("AllTickets")]
        public async Task<IEnumerable<DataLayer.Entities.Ticketing.Ticket>> GetAllTickets()        
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            return await _ticketService.GetAllTickets(userId);
        }
        //مشاهده مدیر فنی و پشتیبان ها بر تیکت های غیرفعال که برای آنها ارسال میشود
        [HttpGet]
        [Route("GetOwner")]
        public async Task<IEnumerable<DataLayer.Entities.Ticketing.Ticket>> GetOwnerTicket()        
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            return await _ticketService.GetOwnerTicket(userId);
        }
        //ویرایش و ثبت آیدی مربوط به شخصی که آخرین چت را انجام داده در جدول تیکت
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
        //به دست آوردن تعداد تیکت ها
        [HttpGet]
        [Route("countTicket")]
        public async Task<ActionResult<int>> GetCountTicket()
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            return await _ticketService.CountTicket(userId); 
        }
    }
}