using NewCrm.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.UniversityService.Interfaces
{
   public interface IUniversity
    {
        Task<bool> UpdateUniversity(UniStatusLogViewModel  uniStatusLogViewModel,string id);
    }
}
