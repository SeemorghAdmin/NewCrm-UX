using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewCrm.Core.DTOs;
using NewCrm.Core.Services.Interfaces;
using NewCrm.DataLayer.Context;

namespace NewCrm.Core.Services
{
    public class AccessCode : IAccessCode
    {
        private readonly NewCrmContext _context;

        public AccessCode(NewCrmContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAccessCode(AccessCodeModel model)
        {
            var user = await _context.People.SingleOrDefaultAsync(u => u.PersonNational_ID == model.UserId);

            user.AccessCodes = model.AccessCodes;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}