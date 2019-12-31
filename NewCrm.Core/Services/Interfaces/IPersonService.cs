using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewCrm.DataLayer.Entities.User;
using NewCrm.Core.DTOs;

namespace NewCrm.Core.Services.Interfaces
{
    public interface IPersonService
    {
        /// <summary>
        /// اضافه کردن شی پرسن به دیتابیس
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Task<string> AddPerson(Person person);
        /// <summary>
        /// چک کردن تکراری نبودن یوزر نیم در دیتابیس
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> IsExistUserName(string userName);
        /// <summary>
        /// چک کردن تکراری نبودن کد ملی در دیتابیس
        /// </summary>
        /// <param name="nationalId"></param>
        /// <returns></returns>
        Task<bool> IsExistNationalId(string nationalId);
        /// <summary>
        /// چک کردن تکراری نبودن ایمیل در دیتابیس
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> IsExistEmail(string email);
        /// <summary>
        /// متد لاگین 
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        Task<Person> Login(LoginViewModel loginViewModel);
        /// <summary>
        /// ارسال لیست پرسن های موجود در یتابیس
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Person>> People();
        Task<IEnumerable<Person>> PeopleDeveloper();
        /// <summary>
        /// متد تغیر پسورد کاربر
        /// </summary>
        /// <param name="personNationalId"></param>
        /// <param name="changePassword"></param>
        /// <returns></returns>
        Task<bool> ChangePassword(string personNationalId, ChangePassword changePassword);
        /// <summary>
        /// ارسال مشخصات کاربر بر اساس ای دی
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Person> UserProfile(string userId);
    }
}
