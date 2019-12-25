﻿ using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.Services.Interfaces
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> People();
        Task<bool> AddStaff(Staff staff);

        Task<bool> PutStaff(string id, RegisterStaffViewModel staff);

        Task<RegisterStaffViewModel> GetStaffEdit(string id);

        Task<bool> DeleteStaff(string id);
    }
}
