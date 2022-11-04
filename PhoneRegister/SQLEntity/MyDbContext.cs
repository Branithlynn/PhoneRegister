using PhoneRegister.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneRegister.SQLEntity
{
    class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Phones> Phone { get; set; }
        public DbSet<Contacts> Contact { get; set; }

        public MyDbContext() : base("Server = localhost\\sqlexpress; Database=PhoneRegister.dbo;Trusted_Connection=True;")
        {
            Users = this.Set<User>();
            Phone = this.Set<Phones>();
            Contact = this.Set<Contacts>();
        }

    }
}
