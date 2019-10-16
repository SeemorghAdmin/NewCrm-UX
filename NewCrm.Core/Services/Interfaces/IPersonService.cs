﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewCrm.DataLayer.Entities.User;

namespace NewCrm.Core.Services.Interfaces
{
    public interface IPersonService
    {
        Task<bool> AddPerson(Person person);

        Task<bool> IsExistUserName(string userName);

        Task<bool> IsExistNationalId(string nationalId);
    }
}
