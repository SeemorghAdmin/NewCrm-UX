using NewCrm.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using NewCrm.DataLayer.Entities.EC;
using Microsoft.EntityFrameworkCore;
using NewCrm.Core.DTOs;

namespace NewCrm.Core.Services
{
    public class AddUniPreData : IUniPreData
    {
        private nernContext _context;

        public AddUniPreData (nernContext nernContext)
        {
            _context = nernContext;
        }


        public async Task<IEnumerable<object>> GetUniPreData()
        {
            var query = from u in _context.PreUniversityData
                        select new
                        {
                            u.Id,
                            u.Address,
                            u.Name,
                            u.UniInternalCode,
                            u.UniNationalCode, 
                            u.SourceVal
                        };
            return query;
        }



    }
}
