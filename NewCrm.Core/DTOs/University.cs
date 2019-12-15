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

        public bool FormatContract { get; set; }

        public bool SinglSignatureContract { get; set; }

        public bool FinalContract { get; set; }

        public bool Letter { get; set; }

        public bool ReceiptPost { get; set; }
    }
}
