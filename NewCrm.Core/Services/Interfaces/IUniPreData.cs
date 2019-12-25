using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Entities.EC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace NewCrm.Core.Services.Interfaces
{
    public interface IUniPreData
    {
        Task<IEnumerable<object>> GetUniPreData();

        Task<bool> AddUniInfo(UniPreData uniPreData);
    }
}