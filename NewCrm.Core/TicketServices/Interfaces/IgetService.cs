using System;
using System.Collections.Generic;
using System.Text;
using NewCrm.DataLayer.Entities.Ticketing;


namespace NewCrm.Core.TicketServices.Interfaces
{
   public interface IgetService
    {
        //اینترفیس مربوط به خواندن اطلاعات سرویس ها از دیتابیس
        IEnumerable<DataLayer.Entities.Ticketing.Services> GetServiceAsync(int id);
    }
}
