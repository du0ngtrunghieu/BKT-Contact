using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_KT.Models
{
    class UserModel
    {

        [Key]
        public int IdUser { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }

    }
}
