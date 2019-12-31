using NewCrm.Core.Services.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.Services
{
    public class DeveloperServices : IDeveloperService
    {

        private NewCrmContext _context;

        public DeveloperServices(NewCrmContext context)
        {
            _context = context;
        }


        public async Task<bool> AddDeveloper(Developer developer)
        {
            await _context.Developers.AddAsync(developer);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
