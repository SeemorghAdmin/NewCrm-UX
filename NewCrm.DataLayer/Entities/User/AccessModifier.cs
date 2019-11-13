using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewCrm.DataLayer.Entities.User
{
    public class AccessModifier
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Active { get; set; }

        public int Cat { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        public string IStering { get; set; }
    }
}