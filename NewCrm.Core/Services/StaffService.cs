using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewCrm.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using NewCrm.DataLayer.Entities.User;
using NewCrm.Core.Services.Interfaces;

namespace NewCrm.Core.Services
{
    public class StaffService : IStaffService
    {
        private NewCrmContext _context;

        public StaffService(NewCrmContext context)
        {
            _context = context;
        }
        public async Task<bool> AddStaff(Staff staff)
        {
            await _context.Staffs.AddAsync(staff);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
