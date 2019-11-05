using NewCrm.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.Services.Interfaces
{
   public interface IDeveloperService
    {
        Task<bool> AddDeveloper(Developer developer);
    }
}
