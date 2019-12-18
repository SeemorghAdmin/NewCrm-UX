﻿using NewCrm.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.Services.Interfaces
{
    public interface IStaffService
    {
        Task<bool> AddStaff(Staff staff);

        Task<bool> PutStaff(int id, Staff staff);
    }
}
