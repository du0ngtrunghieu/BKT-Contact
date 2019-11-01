using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_KT.Models
{
    class ContactModel
    {
        public int IdContact { get; set; }
        public String FullName { get; set; }

        public String firstWordName
        {
            get
            {
                return FullName.Substring(0, 1);
            }
        }
        public int Phone { get; set; }
        public String Email { get; set; }
    }
}
