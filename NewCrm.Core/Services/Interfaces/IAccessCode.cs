using System.Collections.Generic;
using System.Threading.Tasks;
using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Entities.User;

namespace NewCrm.Core.Services.Interfaces
{
    public interface IAccessCode
    {
        Task<bool> AddAccessCode(AccessCodeModel accessCodeModel);

        Task<IEnumerable<AccessModifier>> GetAccessModifier();
    }
}