using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewCrm.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using NewCrm.DataLayer.Entities.User;
using NewCrm.Core.Services.Interfaces;
using System.Linq;
using NewCrm.Core.DTOs;

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

        public async Task<RegisterStaffViewModel> GetStaffEdit(string id)
        {
            var query = await (from s in _context.People
                               join u in _context.Staffs on s.PersonNational_ID equals u.PersonNational_ID
                               select new RegisterStaffViewModel
                               {
                                   Address = u.Address,
                                   BirthDate = Convert.ToInt32(s.BirthDate.Year),
                                   EduDegree = u.EduDegree,
                                   EduField = u.EduField,
                                   PersonNationalId = u.PersonNational_ID,
                                   StaffNumber = u.StaffNumber,
                                   TeleNumber = u.TeleNumber,
                                   FirstName = s.FirstName,
                                   LastName = s.LastName,
                                   FatherName = s.FatherName,
                                   ShenasNum = s.ShenasNum,
                                   ShenasSerial = s.ShenasSerial,
                                   PositionId = u.PositionId
                               }).ToListAsync();
            return query[0];
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

        public async Task<bool> PutStaff(int id, RegisterStaffViewModel register)
        {
            var st = await _context.Staffs.SingleOrDefaultAsync(a => a.PersonNational_ID == id.ToString());
            var person = await _context.People.SingleOrDefaultAsync(a => a.PersonNational_ID == id.ToString());
            st.Address = register.Address;
            st.EduDegree = register.EduDegree;
            st.EduField = register.EduField;
            st.PositionId = register.PositionId;
            st.StaffNumber = register.StaffNumber;
            st.TeleNumber = register.TeleNumber;
            
            person.BirthDate = new DateTime(register.BirthDate);
            person.FirstName = register.FirstName;
            person.LastName = register.LastName;
            person.FatherName = register.FatherName;
            person.ShenasNum = register.ShenasNum;
            person.ShenasSerial = register.ShenasSerial;
            person.LastEditTime = DateTime.Now;

            
            _context.Entry(st).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
           
            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
