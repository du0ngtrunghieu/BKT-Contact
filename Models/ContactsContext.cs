using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_KT.Models
{
    class ContactsContext:DbContext
    {
        public ContactsContext()
           : base("Data Source=ADMIN;Initial Catalog=Contacts;Persist Security Info=True;User ID=sa;Password=1234")
        {

        }
        public DbSet<ContactModel> ContactDbset { get; set; }
        public DbSet<UserModel> UserDbset { get; set; }

    }
}
