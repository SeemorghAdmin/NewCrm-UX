using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewCrm.Core.DTOs;
using NewCrm.Core.Services.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.User;

namespace NewCrm.Core.Services
{
    public class AccessCode : IAccessCode
    {
        // ایجاد شی دیتاکانتکس
        private readonly NewCrmContext _context;
        // مقدار دهی شی دیتاکانتکس در دیتابیس
        public AccessCode(NewCrmContext context)
        {
            _context = context;
        }
        // مقدار دهی اکسس کود کاربر
        public async Task<bool> AddAccessCode(AccessCodeModel model)
        {
            // پیدا کردن کاربر بر اساس یوزر ای دی
            var user = await _context.People.SingleOrDefaultAsync(u => u.PersonNational_ID == model.UserId);
            //قرار دادن اکسس کد در فیلد اکسس کود کاربر
            user.AccessCodes = model.AccessCodes;
            // ذخیره سازی دیتابیس
            await _context.SaveChangesAsync();

            return true;
        }
        // ارسال اکسس کد های دیتابیس
        public async Task<IEnumerable<AccessModifier>> GetAccessModifier()
        {
            var df = await _context.AccessModifiers.Where(a => a.Category == 2).ToListAsync();
            return await _context.AccessModifiers.Where(a => a.Category == 2).ToListAsync();
        }
    }
}