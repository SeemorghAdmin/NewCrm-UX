using System;
using System.Collections.Generic;
using System.Text;

namespace NewCrm.Core.DTOs
{
    public class ServiceFormViewModel
    {
        public long? Id { get; set; }
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
