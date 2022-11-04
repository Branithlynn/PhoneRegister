using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PhoneRegister.Entity
{
    [Table("Contacts")]
    class Contacts
    {
        [Key]
        public int ID { get; set; }
        public int ParentID { get; set; }
        public int ContactNumber { get; set; }
        public string ContactName { get; set; }
    }
}
