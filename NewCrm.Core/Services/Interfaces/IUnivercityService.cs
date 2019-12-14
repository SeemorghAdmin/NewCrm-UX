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
        Task<bool> Delete(long id);

        Task<IEnumerable<ServiceFormViewModel>> GetServiceForm();

        Task<bool> DeleteServiceForm(int id);

        Task<IEnumerable<object>> GetAllUniversity();
    }
}