using System.Collections.Generic;
using System.Threading.Tasks;
using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Entities.User;

namespace NewCrm.Core.Services.Interfaces
{
    public interface IAccessCode
    {
        /// <summary>
        /// اضافه کردن اکسس کد به دیتابیس
        /// </summary>
        /// <param name="accessCodeModel"></param>
        /// <returns></returns>
        Task<bool> AddAccessCode(AccessCodeModel accessCodeModel);
        /// <summary>
        /// ارسال کد های اکسس به انگولار
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AccessModifier>> GetAccessModifier();
    }
}