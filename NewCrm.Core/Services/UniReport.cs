using NewCrm.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewCrm.Core.Services
{
    public class UniReport : IUniReport
    {
        public string Test(string id)
        {
            return id;
        }
    }
}
