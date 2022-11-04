using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PhoneRegister.Entity
{
    [Table("Phones")]
    class Phones
    {
        [Key]
        public int ID { get; set; }
        public int ParentID { get; set; }
        public int PhoneNumber { get; set; }
    }
}
