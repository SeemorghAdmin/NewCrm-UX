using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewCrm.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using NewCrm.DataLayer.Entities.User;
using NewCrm.Core.Services.Interfaces;
using System.Linq;

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

        public async Task<IEnumerable<Staff>> People()
        {
            var Staff = await(from a in _context.Staffs.Include(a => a.Person)
                       
                                where a.Person.Role1 ==2 && a.Person.Role2 == 2
                                select new Staff
                                {
                                    StaffNumber = a.StaffNumber,
                                    Person = a.Person,
                                    PositionId = a.PositionId,
                                    PersonNational_ID = a.PersonNational_ID,
                                    Address = a.Address,
                                    TeleNumber = a.TeleNumber,
                                    EduDegree = a.EduDegree,
                                    EduField = a.EduField,
                                }).ToListAsync();
            return Staff;
        }

        public async Task<bool> PutStaff(int id, Staff staff)
        {
            var st = await _context.Staffs.SingleOrDefaultAsync(a => a.PersonNational_ID == id.ToString());

            return true;
        }
    }
}
