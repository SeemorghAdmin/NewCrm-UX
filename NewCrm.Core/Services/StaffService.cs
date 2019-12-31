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
        // ایجاد شی دیتاکانتکس
        private NewCrmContext _context;
        // مقدار دهی شی دیتاکانتکس در دیتابیس
        public StaffService(NewCrmContext context)
        {
            _context = context;
        }
        // اضافه کردن استف به دیتابیس
        public async Task<bool> AddStaff(Staff staff)
        {
            await _context.Staffs.AddAsync(staff);
            // ذخیره سازی دیتابیس

            await _context.SaveChangesAsync();

            return true;
        }
        // حذف استف
        public async Task<bool> DeleteStaff(string id)
        {
            var staff = await _context.People.SingleOrDefaultAsync(a => a.PersonNational_ID == id);
            // فالس کردن مقدار اکتیو استف
            staff.IsActive = false;
            _context.Entry(staff).State = EntityState.Modified;
            // ذخیره سازی دیتابیس

            await _context.SaveChangesAsync();
            return true;
        }
        // ارسال کاربر انتخابی برای ادیت کردن استف
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
            var user = query.SingleOrDefault(a => a.PersonNationalId == id);
            return user;
        }
        //خواندن لیستی از اطلاعات از جدول دیتابیس
        public async Task<IEnumerable<Staff>> People()
        {
            var Staff = await(from a in _context.Staffs.Include(a => a.Person)
                       
                                where a.Person.Role1 ==2 && (a.Person.Role2 == 2 || a.Person.Role2 == 1)
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
        // ادیت کردن استف
        public async Task<bool> PutStaff(string id, RegisterStaffViewModel register)
        {
            // پیدا کردن استف و ئرسن بر اساس ای دی
            var st = await _context.Staffs.SingleOrDefaultAsync(a => a.PersonNational_ID == id.ToString());
            var person = await _context.People.SingleOrDefaultAsync(a => a.PersonNational_ID == id.ToString());
            // قرار دادن مقدار جدید در استف
            st.Address = register.Address;
            st.EduDegree = register.EduDegree;
            st.EduField = register.EduField;
            st.PositionId = register.PositionId;
            st.StaffNumber = register.StaffNumber;
            st.TeleNumber = register.TeleNumber;
            //قرار دادن مقدار جدید در پرسن
            person.BirthDate = new DateTime(register.BirthDate);
            person.FirstName = register.FirstName;
            person.LastName = register.LastName;
            person.FatherName = register.FatherName;
            person.ShenasNum = register.ShenasNum;
            person.ShenasSerial = register.ShenasSerial;
            person.LastEditTime = DateTime.Now;

            // اپدیت کردن استف در دیتابیس
            _context.Entry(st).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
           // اپدیت کردن پرسن در دیتابیس
            _context.Entry(person).State = EntityState.Modified;
            // ذخیره سازی دیتابیس

            _context.SaveChanges();
            return true;
        }
    }
}
