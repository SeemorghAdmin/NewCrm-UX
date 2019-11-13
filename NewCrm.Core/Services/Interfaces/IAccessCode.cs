using System.Threading.Tasks;
using NewCrm.Core.DTOs;

namespace NewCrm.Core.Services.Interfaces
{
    public interface IAccessCode
    {
        Task<bool> AddAccessCode(AccessCodeModel accessCodeModel);
    }
}