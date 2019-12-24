using Microsoft.EntityFrameworkCore;
using NewCrm.Core.DTOs;
using NewCrm.Core.UniversityService.Interfaces;
using NewCrm.DataLayer.Entities.EC;
using NewCrm.DataLayer.Entities.UniStatus;
using NewCrm.DataLayer.Entities.UniSubStatus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace NewCrm.Core.UniversityService
{
    public class UniversityService : IUniversity
    {
        private nernContext  _context;
        //Status ایجاد لیستی از کلاس 
        List<Status> status;
       // SubStatus ایجاد لیستی از کلاس
        List<SubStatus> substatus;

        public UniversityService(nernContext context)
        {
            _context = context;
            //پر کردن لیست ایجاد شده با پارامتر های زیر
            status = new List<Status>
            {
                 new Status {Id = 1, Text="انتظار برای تایید درخواست عضویت" },
                 new Status {Id = 2, Text="اصلاح خطا در فرم درخواست عضویت" },
                 new Status {Id = 3, Text="انتظار برای تایید درخواست توسط دستگاه مربوطه" },
                 new Status {Id = 1000, Text="ارسال قرارداد اشتراک جهت امضاء متقاضی" },
                 new Status {Id = 1001, Text="انتظار تایید اشتراک توسط اپراتور" },
                 new Status {Id = 1002, Text="اصلاح خطا در فرم درخواست اشتراک" },
                 new Status {Id = 1003, Text="انتظار برای بررسی  در فاز بعد" },
                 new Status {Id = 2000, Text="ثبت نام مسئول اصلی" },
                 new Status {Id = 3000, Text="ثبت قرارداد" },
                 new Status {Id = 3001, Text="تایید ویرایش دانشگاه ها" },
                 new Status {Id = 3002, Text="تایید ویرایش مسئول اصلی" },
                 new Status {Id = 3003, Text="انتظار برای تایید درخواست لغو عضویت" },
                 new Status {Id = 3004, Text="تایید نهایی لغو عضویت" },
                 new Status {Id = 3005, Text="تایید ویرایش دانشگاه ها" },
                 new Status {Id = 3006, Text="ثبت سرویس فرم" },
            };
            //پر کردن لیست تشکیل شده با پارامتر های زیر
            substatus = new List<SubStatus>
            {
                 new SubStatus {Id = 0, Text="مشکل در فایل درخواست عضویت" },
                 new SubStatus {Id = 1, Text="مشکل در نام بالاترین مقام" },
                 new SubStatus {Id = 2, Text="مشکل در شماره تلفن" },
                 new SubStatus {Id = 3, Text="مشکل در شماره فکس" },
                 new SubStatus {Id = 4, Text="شهر اشتباه" },
                 new SubStatus {Id = 5, Text="استان اشتباه" },
                 new SubStatus {Id = 6, Text="آدرس اشتباه" },
                 new SubStatus {Id = 7, Text="کد پستی اشتباه" },
                 new SubStatus {Id = 8, Text="مشکل در پست الکترونیک" },
                 new SubStatus {Id = 9, Text="مکان اشتباه روی نقشه" },
                 new SubStatus {Id = 1000, Text="شخص امضاء کننده مجاز به امضاء نبوده" },
                 new SubStatus {Id = 1001, Text="فرمت قرارداد ارسالی مطابقت ندارد" },
            };
        }
        //متد ویرایش پارامترهای تعیین شده در مای اس کیو ال
        public async Task<bool> UpdateUniversity(UniStatusLogViewModel uniStatusLogViewModel,string id)
        {
            long b = Convert.ToInt64(id);
            UserRole userRole =await _context.UserRole.SingleOrDefaultAsync(a => a.NationalId == b);
            long RoleId = userRole.RoleId;
            Admin admin = await _context.Admin.SingleOrDefaultAsync(ad => ad.RoleId == RoleId);
            University university = await _context.University.SingleOrDefaultAsync(au => au.UniNationalId == uniStatusLogViewModel.UniNationalId);
            university.UniStatus = uniStatusLogViewModel.UniStatus;
            university.UniSubStatus = uniStatusLogViewModel.UniSubStatus;
            //با استفاده از کد خط زیر پارامتر های جا گذاری شده در جدول ویرایش میشوند 
            _context.Entry(university).State = EntityState.Modified;
            //ایجاد یک نمونه از کلاس مربوطه
                UniStatusLog uniStatusLog = new UniStatusLog();

            if(uniStatusLogViewModel.msg == "")
            {
                Status o=status.Find(a => a.Id == uniStatusLogViewModel.UniStatus);
                
                if(uniStatusLogViewModel.UniSubStatus == 0)
                {
                    uniStatusLog.Message = "تغییر وضعیت به " + o.Text;
                }
                else
                {
                    SubStatus oo = substatus.Find(a => a.Id == uniStatusLogViewModel.UniSubStatus);
                    uniStatusLog.Message = "تغییر وضعیت به " + o.Text + " زیر وضعیت به " + oo.Text;
                }
            }
            else
            {
                uniStatusLog.Message = uniStatusLogViewModel.msg;
            }
                uniStatusLog.TimeStamp = DateTime.Now;
                uniStatusLog.UniNationalId = uniStatusLogViewModel.UniNationalId;
                uniStatusLog.UniStatus = uniStatusLogViewModel.UniStatus;
                if (uniStatusLogViewModel.UniSubStatus != 0)
                {
                    uniStatusLog.UniSubStatus = uniStatusLogViewModel.UniSubStatus;
                }
               uniStatusLog.ApprovalAdminId = admin.Id;
            //اضافه کردن پارامتر های جاگذاری شده در جدول مای اس کیو ال
               await _context.UniStatusLog.AddAsync(uniStatusLog);
                await _context.SaveChangesAsync();
                return true;
        }
    }
}
