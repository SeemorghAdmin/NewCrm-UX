using Microsoft.EntityFrameworkCore;
using NewCrm.Core.DTOs;
using NewCrm.Core.Services.Interfaces;
using NewCrm.DataLayer.Context;
using NewCrm.DataLayer.Entities.EC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCrm.Core.Services
{
    public class AddUniPreData : IUniPreData
    {
        private nernContext _context;

        public AddUniPreData(nernContext context)
        {
            _context = context;
        }


        //اطلاعاتی که در هریک از فیلدهای جدول بالایی در صفحه اضافه کردن اطلاعات دانشگاه های پیش فرض نوشته شده را 
        // در ستون مناسب داخل دیتابیس ذخیره می کند.
        public async Task<bool> AddUniInfo(UniPreData uniPreData)
        {
            PreUniversityData preUniversityData = new PreUniversityData()
            {
                Address = uniPreData.Address,
                Name = uniPreData.Uniname,
                UniInternalCode = Convert.ToInt64(uniPreData.Unicode),
                SourceVal = uniPreData.UniType
            };

            await _context.PreUniversityData.AddAsync(preUniversityData);
            await _context.SaveChangesAsync();
            return true;
        }

        //از دیتابیس اطلاعات موجود در فیلدهای نوشته شده را می خواند.
        public async Task<IEnumerable<object>> GetUniPreData()
        {
            var query =await( from u in _context.PreUniversityData
                        select new
                        {
                            u.Id,
                            u.Address,
                            u.Name,
                            u.UniInternalCode,
                            u.UniNationalCode,
                            u.SourceVal
                        }).ToListAsync();
            return query;
        }

        public async Task<bool> IsExistNational(string id)
        {
            var f = await _context.PreUniversityData.ToListAsync();
            foreach (var item in f)
            {
                if (item.UniInternalCode == Convert.ToInt64(id))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

