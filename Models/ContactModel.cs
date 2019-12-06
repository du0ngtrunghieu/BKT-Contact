using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_KT.Models
{
    class ContactModel
    {
        [Key]
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
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public UserModel user { get; set; }
    }
}
