using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewCrm.DataLayer.Entities.User
{
    public class AccessModifier
    {
        [Key]
        public int AccessModifier_ID { get; set; }

        public string Title { get; set; }

        public bool Active { get; set; }

        public int Category { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        public string IString { get; set; }
    }
}