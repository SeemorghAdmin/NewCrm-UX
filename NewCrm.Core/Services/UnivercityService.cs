using NewCrm.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace NewCrm.Core.Services
{
    public class UnivercityService : IUnivercityService
    {
        private List<Uni> _uni = new List<Uni>
        {
            new Uni { UniId = 1, UniName = "Test1"},
            new Uni { UniId = 2, UniName = "Test2"},
            new Uni { UniId = 3, UniName = "Test3"}
        };

        public List<ServiceF> serviceFs = new List<ServiceF>
        {
            new ServiceF { UniName = "test1", Title = "test1", Status = "ok", Number = "123456", Time = "1398",
                FinalContract = "test", FormatContract = "teee", Letter = "test", ReceiptPost = "ddd", SinglSignatureContract = "fffff"},
            new ServiceF { UniName = "test2", Title = "test2", Status = "ok", Number = "123456", Time = "1398",
                FinalContract = "test", FormatContract = "teee", Letter = "test", ReceiptPost = "ddd", SinglSignatureContract = "fffff"},
            new ServiceF { UniName = "test3", Title = "test3", Status = "ok", Number = "123456", Time = "1398",
                FinalContract = "test", FormatContract = "teee", Letter = "test", ReceiptPost = "ddd", SinglSignatureContract = "fffff"},
            new ServiceF { UniName = "test4", Title = "test4", Status = "ok", Number = "123456", Time = "1398",
                FinalContract = "test", FormatContract = "teee", Letter = "test", ReceiptPost = "ddd", SinglSignatureContract = "fffff"},
            new ServiceF { UniName = "test5", Title = "test5", Status = "ok", Number = "123456", Time = "1398",
                FinalContract = "test", FormatContract = "teee", Letter = "test", ReceiptPost = "ddd", SinglSignatureContract = "fffff"},
            new ServiceF { UniName = "test6", Title = "test6", Status = "ok", Number = "123456", Time = "1398",
                FinalContract = "test", FormatContract = "teee", Letter = "test", ReceiptPost = "ddd", SinglSignatureContract = "fffff"},
            new ServiceF { UniName = "test7", Title = "test7", Status = "ok", Number = "123456", Time = "1398",
                FinalContract = "test", FormatContract = "teee", Letter = "test", ReceiptPost = "ddd", SinglSignatureContract = "fffff"},
        };
        public bool Delete(int id)
        {
            var uni = _uni.First(a => a.UniId == id);
            _uni.Remove(uni);
            return true;
        }

        public IEnumerable<object> GetServiceForm()
        {
            return serviceFs.ToList();
        }
    }

    public class Uni
    {
        public int UniId { get; set; }

        public string UniName { get; set; }
    }

    public class ServiceF
    {
        public string UniName { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string Number { get; set; }

        public string Time { get; set; }

        public string FormatContract { get; set; }

        public string SinglSignatureContract { get; set; }

        public string FinalContract { get; set; }

        public string Letter { get; set; }

        public string ReceiptPost { get; set; }
    }
}
