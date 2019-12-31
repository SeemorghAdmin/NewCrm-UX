using NewCrm.Core.DTOs;
using NewCrm.DataLayer.Entities.EC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.Services.Interfaces
{
    public interface IUnivercityService
    {
        /// <summary>
        /// حذف دانشگاه که مقدار ترو فیلد اکتیو را فالس میکند
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(long id);
        /// <summary>
        /// ارسال سرویس فرم ها به کلاینت
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ServiceFormViewModel>> GetServiceForm();
        /// <summary>
        /// حذف کردن سرویس فرم که مقدار ترو فیلد اکتیو را فالس میکند
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteServiceForm(int id);

        Task<IEnumerable<object>> GetAllUniversity();
        /// <summary>
        /// ویرایش دانشگاه در دیتابیس
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> PutUni(UniversityViewModel model);
    }
}