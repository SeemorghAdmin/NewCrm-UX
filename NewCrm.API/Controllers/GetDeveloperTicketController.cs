using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewCrm.Core.DeveloperTicketServices.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.TicketForDeveloper;

namespace NewCrm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDeveloperTicketController : ControllerBase
    {
        private NewCrmContext _context;
        private IDeveloperTicketService _developerTicketService;
        public GetDeveloperTicketController(NewCrmContext context, IDeveloperTicketService iDeveloperTicketService)
        {
            _context = context;
            _developerTicketService = iDeveloperTicketService;
        }
        //////نمایش تیکت های ایجاد شده توسط هر فرد//////
        [HttpGet]
        public async Task<IEnumerable<DeveloperTicket>> GetTicket()
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            return await _developerTicketService.GetTicket(userId);
        }
        //////نمایش تیکت ها به مدیر خاشع/////
        [HttpGet]
        [Route("TicketForOwnerManager")]
        public async Task<IEnumerable<DeveloperTicket>> GetTicketForOwnerManager()
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            return await _developerTicketService.GetTicketForOwnerManager(userId);
        }
       /////نمایش تیکت های ارسالی به برنامه نویسان//////
        [Route("DeveloperTcketChat")]
        public async Task<IEnumerable<DeveloperTicketChat>> GetDeveloperTicketChat(int id)
        {
            string userId = User.Claims.First(c => c.Type == "seemsys").Value;
            return await _developerTicketService.GetDeveloperTicketChat(id, userId);
        }
    }
}