using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewCrm.Core.Services.Interfaces
{
    public interface IUnivercityService
    {
        bool Delete(int id);

        IEnumerable<object> GetServiceForm();
    }
}
