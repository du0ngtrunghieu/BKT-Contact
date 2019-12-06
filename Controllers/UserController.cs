using Contacts_KT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_KT.Controllers
{
    class UserController
    {
        
        public static UserModel CheckUserLogin(String username, String pass)
        {
            var db = new ContactsContext();
            UserModel user = db.UserDbset.Where(x => x.UserName == username && x.Password == pass).FirstOrDefault();
            if(user != null)
            {
                return user;
            }

            return null;
        } 
    }
}
