using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewCrm.DataLayer.Entities.Upload
{
   public class ServiceFileUpload
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public int Unumber { get; set; }
        public string TypeOfFile { get; set; }
    }
}
