 using NewCrm.Core.DTOs;
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
        /// <summary>
        /// اضافه کرردن کارمند خاشع به دیتابیس
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        Task<bool> AddStaff(Staff staff);
        /// <summary>
        /// ویرایش اطلاعات کارمند خاشع در دیتابیس
        /// </summary>
        /// <param name="id"></param>
        /// <param name="staff"></param>
        /// <returns></returns>
        Task<bool> PutStaff(string id, RegisterStaffViewModel staff);
        /// <summary>
        /// ارسال کاربر انتخاب شده برای ویرایش
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RegisterStaffViewModel> GetStaffEdit(string id);
        /// <summary>
        /// حذف کاربر خاشع که مقدار ترو فیلد اکتیو را به فالس تغییر میدهد
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteStaff(string id);
    }
}
