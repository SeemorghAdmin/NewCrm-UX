using NewCrm.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.UniversityService.Interfaces
{
   public interface IUniversity
    {
        //ایجاد اینترفیس برای ویرایش و اضافه کردن اطلاعات همزمان در دو جدول//Uiversity & UniStatusLog
        Task<bool> UpdateUniversity(UniStatusLogViewModel  uniStatusLogViewModel,string id);
    }
}
