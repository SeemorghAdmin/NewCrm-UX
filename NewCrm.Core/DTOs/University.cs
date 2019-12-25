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

    public class UniversityViewModel
    {
        public long UniNationalId { get; set; }
        public string UniName { get; set; }
        public string UniEcoCode { get; set; }
        public string UniTopManagerName { get; set; }
        public string UniTopManagerPos { get; set; }
        public string UniSignatoryPos { get; set; }
        public string UniSignatoryNationalId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string UniAddress { get; set; }
        public string UniPostalCode { get; set; }
        public string UniTelNo { get; set; }
        public string AgentFaxNo { get; set; }
        public string UniWebsite { get; set; }
        public string UniEmail { get; set; }
        public string AgentFname { get; set; }
        public string AgentLname { get; set; }
        public string AgentNationalId { get; set; }
        public string AgentPos { get; set; }
        public string AgentTeleNo { get; set; }
        public string AgentMobileNo { get; set; }
    }
}
